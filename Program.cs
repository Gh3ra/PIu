using System;
using System.Configuration;
using Librarie;
using NivelStocare;

namespace Masinele
{
    class Program
    {
        static void Main(string[] args)
        {
            string marca;
            string model;
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            MasiniFisier adminMasini = new MasiniFisier(numeFisier);
            Masina  MasinaNoua = new Masina ();
            int nrMasini = 0;
            // acest apel ajuta la obtinerea numarului de masini inca de la inceputul executiei
            // astfel incat o eventuala adaugare sa atribuie un IdMasina corect masina noua
            adminMasini.GetMasini(out nrMasini);

            string optiune;
            do
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("| C. Citire informatii despre masina de la tastatura|");
                Console.WriteLine("| A. Afisarea ultimei Masini introduse              |");
                Console.WriteLine("| F. Afisare masinilor din fisier                   |");
                Console.WriteLine("| S. Salvare masina in fisier                       |");
                Console.WriteLine("| D. Cautare masina dupa marca si model             |");
                Console.WriteLine("| X. Inchidere program                              |");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("<-======== Alegeti o optiune =======->");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "C":
                        MasinaNoua = CitireMasinaTastatura();

                        break;
                    case "A":
                        AfisareMasina(MasinaNoua);

                        break;
                    case "F":
                        Masina [] masini = adminMasini.GetMasini(out nrMasini);
                        AfisareMasini(masini, nrMasini);

                        break;
                    case "S":
                        int idMasina = nrMasini + 1;
                        MasinaNoua.SetIdMasina(idMasina);
                        //adaugare masina in fisier
                        adminMasini.AddMasina(MasinaNoua);

                        nrMasini = nrMasini + 1;

                        break;

                    case "D":
                        Console.Write(" Marca masinii: ");
                        marca = Console.ReadLine();
                        Console.Write(" Modelul masinii: ");
                        model = Console.ReadLine();

                        Masina masina_cautata = adminMasini.GetMasina(marca, model);
                        if (string.IsNullOrEmpty(masina_cautata.GetMarca()) && string.IsNullOrEmpty(masina_cautata.GetModel()))
                        {

                            Console.WriteLine("Nu avem aceasta masina\n");

                        }
                        else
                        {

                            string info_masina_cautata = string.Format("Masina cu id-ul {0} si marca {1} avand modelul {2}\n",
                                masina_cautata.GetIdMasina(), masina_cautata.GetMarca(), masina_cautata.GetModel());
                            Console.WriteLine(info_masina_cautata);


                        }
                        break;

                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        public static void AfisareMasina(Masina  masina)
        {
            string infoMasina = string.Format("Masina cu id-ul #{0} are marca: {1} {2}",
                   masina.GetIdMasina(),
                   masina.GetMarca() ?? " NECUNOSCUT ",
                   masina.GetModel() ?? " NECUNOSCUT ");

            Console.WriteLine(infoMasina);
        }

        public static void AfisareMasini(Masina [] masini, int nrMasini)
        {
            Console.WriteLine("Masinile disponib sunt:");
            for (int contor = 0; contor < nrMasini; contor++)
            {
                AfisareMasina(masini[contor]);
            }
        }

        public static Masina  CitireMasinaTastatura()
        {
            Console.WriteLine("Introduceti marca:");
            string marca = Console.ReadLine();

            Console.WriteLine("Introduceti modelul:");
            string model = Console.ReadLine();

            Masina masina = new Masina (0, marca, model);

            return masina;  
        }
    }
}
