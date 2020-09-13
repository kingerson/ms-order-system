using System.Globalization;

namespace MS.ProductsWithoutArtifact
{
    public static class Core
    {
        public static string GetNameFormat(string name)
        {
            CultureInfo ci = new CultureInfo("es-PE");
            TextInfo textInfo = ci.TextInfo;
            var result = textInfo.ToTitleCase(name);
            return result;
        }
    }
}
