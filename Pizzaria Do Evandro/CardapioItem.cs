using Android.Graphics;

namespace Pizzaria_Do_Evandro
{
    class CardapioItem
    {
        public string Descricao { get; set; }
        public Bitmap Imagem { get; set; }

        public CardapioItem()
        {

        }

        public CardapioItem(string desc, Bitmap img)
        {
            Descricao = desc;
            Imagem = img;
        }
    }
}