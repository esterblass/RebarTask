namespace RebarProject.Models
{
    public class Menu
    {
        public static List<Shake> menu = new List<Shake>();
        public static void AddShake(Shake s)
        {
            menu.Add(s);
        }



        //public List<Shake> shakesList { get; set; }

        //public void addShake(Shake shake)
        //{
        //    shakesList.Add(shake);
        //}

    }
}
