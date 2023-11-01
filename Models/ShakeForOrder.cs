namespace RebarProject.Models
{
    public class ShakeForOrder
    {
        public string name { get; set; }
        public string size { get; set; }
        public int price { get; set; }

        public ShakeForOrder(string Name, string Size)
        {
            name = Name;

            size = Size;
            foreach (Shake s in Menu.menu)
            {
                if (s.name == name)
                {
                    switch (size)
                    {
                        case "s":
                            price = s.smallPrice;
                            break;
                        case "m":
                            price = s.mediumPrice;
                            break;
                        case "l":
                            price = s.largePrice;
                            break;
                    }
                }
            }

        }
    
}
}
