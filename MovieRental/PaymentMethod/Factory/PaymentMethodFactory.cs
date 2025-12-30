using MovieRental.PaymentProviders;

namespace MovieRental.PaymentMethod.Factory
{
    public static class PaymentMethodFactory
    {
        public static IPaymentProvider GetProvider(int method) { 
            return method switch {
                1 => new MbWayProvider(), 
                2 => new PayPalProvider(), 
                _ => throw new NotSupportedException($"Payment method '{method}' is not supported.") }; }
    }
}
