using System;

namespace CanteenBoard.Entities.Menu
{
    [Flags]
    public enum Allergen
    {
        Cereals = 0x0001,
        Crustaceans = 0x0002,
        Eggs = 0x0004,
        Fish = 0x0008,
        Peanuts = 0x0010,
        Soybeans = 0x0020,
        Milk = 0x0040,
        Nuts = 0x0080,
        Celery = 0x0100,
        Mustard = 0x0200,
        Sesame = 0x0400,
        SulphurDioxide = 0x0800,
        Lupin = 0x1000,
        Molluscs = 0x2000
    }
}
