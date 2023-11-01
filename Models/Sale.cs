namespace RebarProject.Models
{
    public class Sale
    {
        public string descriotion { get; set; }
        public int percent { get; set; }

        public Sale(string Description, int Percent)
        {
            descriotion = Description;
            percent = Percent;
        }
    }

}
