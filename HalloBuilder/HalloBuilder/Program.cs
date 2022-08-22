// See https://aka.ms/new-console-template for more information
using CommunityToolkit.Diagnostics;

Console.WriteLine("Hello, World!");

var schrank1 = new Schrank.Builder()
                          .SetOberfläche(Oberfläche.Lackiert)
                          .SetFarbe("   ")
                          .SetTüren(4)
                          .Create();

class Schrank
{

    public class Builder
    {
        Schrank _newSchrank = new Schrank();

        public Builder SetTüren(int anzTüren)
        {
            if (anzTüren < 2 || anzTüren > 7)
                throw new ArgumentException();

            _newSchrank.AnzTüren = anzTüren;
            return this;
        }

        public Builder SetFarbe(string farbe)
        {
            Guard.IsNotNullOrWhiteSpace(farbe);
            Guard.IsFalse(_newSchrank.Oberfläche != Oberfläche.Lackiert);

            //if()
            //    throw new ArgumentException("Farbe nur wenn Lackiert!!!");


            _newSchrank.Farbe = farbe;
            return this;
        }

        public Builder SetOberfläche(Oberfläche oberfläche)
        {
            _newSchrank.Oberfläche = oberfläche;
            return this;
        }
        public Builder SetBöden(int anzBöden)
        {
            _newSchrank.AnzBöden = anzBöden;
            return this;
        }

        public Builder SetStange(bool stange)
        {
            _newSchrank.Kleiderstange = stange;
            return this;
        }

        public Schrank Create()
        {
            return _newSchrank;
        }
    }

    private Schrank()
    { }

    public int AnzTüren { get; private set; }
    public int AnzBöden { get; private set; }
    public string Farbe { get; private set; }
    public bool Kleiderstange { get; private set; }
    public Oberfläche Oberfläche { get; private set; }

}

enum Oberfläche
{
    Unbehandelt,
    Gewachst,
    Lackiert
}
