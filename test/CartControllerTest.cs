using Xunit;
using Services;
using Services.Model;
using Moq;
using api.Controllers;

namespace test
{
    public class CartControllerTest
    {
 
        [Fact()]
        public void TestPostCharged()
        {
            // SETUP MOCKED DATA
            var checkoutDtoMock = new Mock<CheckoutDto>();
            var items = new CartItem[0];

            // GIVEN MOCKED SEERVICES: Payment returns 'true'
            var paymentServiceMock = new Mock<IPaymentService>();                                         // create service mock
            paymentServiceMock.Setup(p => p.Charge(It.IsAny<double>(), It.IsAny<Card>())).Returns(true);  // setup Service what to return on call

            var cartServiceMock = new Mock<ICartService>();
            var shipmentServiceMock = new Mock<IShipmentService>();
            var controller = new CartController(cartServiceMock.Object, paymentServiceMock.Object, shipmentServiceMock.Object);

            // WHEN
            var actual = controller.Post(checkoutDtoMock.Object);
            var expected = "charged";

            // THEN          
            shipmentServiceMock.Verify(s => s.Ship(null, items), Times.Once());  // Assert Behavior
            Assert.Equal(expected, actual);                                      // Assert Value
        }
        
        [Fact()]
        public void TestPostNotCharged()
        {
            // SETUP MOCKED DATA
            var checkoutDtoMock = new Mock<CheckoutDto>();
            var items = new CartItem[0];

            // GIVEN MOCK SETUP: Payment returns 'false'
            var paymentServiceMock = new Mock<IPaymentService>();                                         // create service mock
            paymentServiceMock.Setup(p => p.Charge(It.IsAny<double>(), It.IsAny<Card>())).Returns(false); // setup Service what to return on call

            var cartServiceMock = new Mock<ICartService>();
            var shipmentServiceMock = new Mock<IShipmentService>();
            var controller = new CartController(cartServiceMock.Object, paymentServiceMock.Object, shipmentServiceMock.Object);

            // WHEN
            var actual = controller.Post(checkoutDtoMock.Object);
            var expected = "not charged";

            // THEN          
            shipmentServiceMock.Verify(s => s.Ship(null, items), Times.Never());  // Assert Behavior
            Assert.Equal(expected, actual);                                       // Assert Value
        }
    }
}
