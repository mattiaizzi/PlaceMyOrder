using System.ComponentModel;

namespace PlaceMyOrder.Core.Model
{
    public enum Course
    {
        [Description("Primo")]
        First = 1,
        [Description("Secondo")]
        Main = 2,
        [Description("Contorno")]
        Side = 3,
        [Description("Dolce")]
        Dessert = 4

    }
}
