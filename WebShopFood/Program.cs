using WebShopFood.Windows;

namespace WebShopFood
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //List<string> topText = new List<string> { "# Fina butiken #", "Allt inom kläder" };
            //var windowTop = new Window("", 2, 1, topText);
            //windowTop.Draw();
            //Methods.Admin.AddCategory();
            //Methods.Admin.AddProducer();
            Methods.Admin.AddProduct();
        }
    }
}
