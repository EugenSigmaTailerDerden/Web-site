using System.Collections.Generic;

// Ваш клас Mobile
public class Mobile
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Category { get; set; }
    public int Price { get; set; } // Змінив 'price' на 'Price' для відповідності конвенціям C#
    public int Quantity { get; set; }
    public int? Discount { get; set; }
}

