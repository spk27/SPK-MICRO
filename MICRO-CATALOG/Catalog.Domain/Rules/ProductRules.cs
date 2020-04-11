

namespace Spk.Catalog.Domain.Rules
{
    public static class ProductRules {
        public const int MaxLengthProductName = 50;
        public static string MaxLengthNameValidation = $"Ha superado la cantidad máxima de caracteres: {MaxLengthProductName}";
        public static string NotEmptyNameValidation = "Falta el nombre del producto";
        public const decimal MinPriceValue = 0m;
        public static string MinPriceValueValidation = "Falta el precio";
        public const decimal MaxPriceValue = 9999999m;
        public static string MaxPriceValueValidation = "Precio muy elevado";

    
    }
}