using Librarie;
using System.IO;

namespace NivelStocare
{
    public class MasiniFisier
    {
        private const int NR_MAX_MASINI = 100;
        private string numeFisier;

        public MasiniFisier(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddMasina(Masina masina)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(masina.ConversieLaSir_PentruFisier());
            }
        }

        public Masina[] GetMasini(out int nrMasini)
        {
            Masina [] masini = new Masina [NR_MAX_MASINI];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrMasini = 0;

                // citeste cate o linie si creaza un obiect de tip Masina
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    masini[nrMasini++] = new Masina(linieFisier);
                }
            }

            return masini;
        }
        public Masina GetMasina(string marca, string model)
        {

            Masina masina;
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {

                string linieFisier;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {

                    masina = new Masina(linieFisier);
                    if (masina.GetMarca() == marca && masina.GetModel() == model)
                    {

                        return masina;

                    }

                }
                Masina masina_invalida = new Masina();
                return masina_invalida;

            }

        }
    }
}