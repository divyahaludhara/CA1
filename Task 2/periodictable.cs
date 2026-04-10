using System;
using System.Collections.Generic;

// Element class
public class Element
{
    public int AtomicNumber;
    public string ElementName, Symbol, Description;

    public Element(int atomicNumber, string elementName, string symbol, string description)
    {
        AtomicNumber = atomicNumber;
        ElementName = elementName;
        Symbol = symbol;
        Description = description;
    }

    public void ShowElement()
    {
        Console.WriteLine("\nElement Information");
        Console.WriteLine("Atomic Number : " + AtomicNumber);
        Console.WriteLine("Element Name  : " + ElementName);
        Console.WriteLine("Symbol        : " + Symbol);
        Console.WriteLine("Description  : " + Description);
    }
}

// Main class
public class MainClass
{
    public static void Main(string[] args)
    {
        Dictionary<int, Element> periodicTable = new Dictionary<int, Element>();

        // First 30 elements
        periodicTable.Add(1, new Element(1, "Hydrogen", "H","Lightest, most abundant gas in the universe, fuel for stars"));
        periodicTable.Add(2, new Element(2, "Helium", "He","Noble gas, colorless, odorless, non-reactive, used in balloons"));
        periodicTable.Add(3, new Element(3, "Lithium", "Li", "Soft, highly reactive alkali metal, used in batteries"));
        periodicTable.Add(4, new Element(4, "Beryllium", "Be", "Lightweight alkaline earth metal, used in aerospace materials"));
        periodicTable.Add(5, new Element(5, "Boron", "B", "Metalloid essential for plant growth and strengthening glass"));
        periodicTable.Add(6, new Element(6, "Carbon", "C", "Basis of all organic life, found in graphite and diamonds."));
        periodicTable.Add(7, new Element(7, "Nitrogen", "N", "Diatomic gas, makes up ~78% of Earth's atmosphere."));
        periodicTable.Add(8, new Element(8, "Oxygen", "O", "Highly reactive gas, essential for respiration."));
        periodicTable.Add(9, new Element(9, "Fluorine", "F", "Most electronegative, highly reactive halogen gas"));
        periodicTable.Add(10, new Element(10, "Neon", "Ne", "Noble gas known for its use in bright, colorful signs"));
        periodicTable.Add(11, new Element(11, "Sodium", "Na", "Soft, highly reactive metal; key part of table salt (NaCl)"));
        periodicTable.Add(12, new Element(12, "Magnesium", "Mg", "Light alkaline earth metal, used in alloys and fireworks"));
        periodicTable.Add(13, new Element(13, "Aluminium", "Al", "Light alkaline earth metal, used in alloys and fireworks"));
        periodicTable.Add(14, new Element(14, "Silicon", "Si", "Semiconductor material foundational to computer chips"));
        periodicTable.Add(15, new Element(15, "Phosphorus", "P", "Essential to life, found in DNA and cell membranes"));
        periodicTable.Add(16, new Element(16, "Sulfur", "S", "Nonmetal crucial for fertilizers and rubber production"));
        periodicTable.Add(17, new Element(17, "Chlorine", "Cl", "Reactive, toxic green gas, used for disinfection"));
        periodicTable.Add(18, new Element(18, "Argon", "Ar", "Noble gas used to create inert atmospheres."));
        periodicTable.Add(19, new Element(19, "Potassium", "K", "Essential metal for biological functions, very reactive"));
        periodicTable.Add(20, new Element(20, "Calcium", "Ca", " Soft metal, essential for bones, teeth, and found in limestone"));
        periodicTable.Add(21, new Element(21, "Scandium", "Sc", "Rare earth metal, used in high-strength aluminum alloys"));
        periodicTable.Add(22, new Element(22, "Titanium", "Ti", "Strong, low-density metal, corrosion-resistant"));
        periodicTable.Add(23, new Element(23, "Vanadium", "V", "Hard transition metal, used in steel alloys"));
        periodicTable.Add(24, new Element(24, "Chromium", "Cr", "Shiny metal, key component of stainless steel"));
        periodicTable.Add(25, new Element(25, "Manganese", "Mn", "Transition metal used to harden steel"));
        periodicTable.Add(26, new Element(26, "Iron", "Fe", "Magnetic, crucial metal for industry and hemoglobin"));
        periodicTable.Add(27, new Element(27, "Cobalt", "Co", "Hard magnetic metal used in batteries and pigments"));
        periodicTable.Add(28, new Element(28, "Nickel", "Ni", "Corrosion-resistant metal used in stainless steel and coins"));
        periodicTable.Add(29, new Element(29, "Copper", "Cu", "Reddish metal, excellent electrical conductor"));
        periodicTable.Add(30, new Element(30, "Zinc", "Zn", " Metal used to galvanize steel to prevent corrosion"));

        char choice;

        do
        {
            Console.Write("\nEnter atomic number (1 to 30): ");
            int atomicNo = Convert.ToInt32(Console.ReadLine());

            if (periodicTable.ContainsKey(atomicNo))
            {
                periodicTable[atomicNo].ShowElement();
            }
            else
            {
                Console.WriteLine("Invalid atomic number. Please enter a number between 1 and 30.");
            }

            Console.Write("\nDo you want to know more elements (y/n): ");
            choice = Convert.ToChar(Console.ReadLine());

        } while (choice == 'y' || choice == 'Y');

        Console.WriteLine("\nThanks !!!");
    }
}