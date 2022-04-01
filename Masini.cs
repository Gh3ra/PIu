using System;

namespace Librarie
{
    public class Masina
    {
        //constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private const int ID = 0;
        private const int MARCA = 1;
        private const int MODEL = 2;

        //proprietati auto-implemented
        private int idMasina; //identificator unic student
        private string marca;
        private string model;

        //contructor implicit
        public Masina()
        {
            marca = model = string.Empty;
        }

        //constructor cu parametri
        public Masina (int idMasina, string marca, string model)
        {
            this.idMasina = idMasina;
            this.marca  = marca;
            this.model = model;
        }

        //constructor cu un singur parametru de tip string care reprezinta o linie dintr-un fisier text
        public Masina(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idMasina = Convert.ToInt32(dateFisier[ID]);
            marca = dateFisier[MARCA];
            model = dateFisier[MODEL];
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectMasinaPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idMasina.ToString(),
                (marca ?? " NECUNOSCUT "),
                (model ?? " NECUNOSCUT "));

            return obiectMasinaPentruFisier;
        }

        public int GetIdMasina()
        {
            return idMasina;
        }

        public string GetMarca()
        {
            return marca;
        }

        public string GetModel()
        {
            return model;
        }

        public void SetIdMasina(int idMasina)
        {
            this.idMasina = idMasina;
        }
    }
}
