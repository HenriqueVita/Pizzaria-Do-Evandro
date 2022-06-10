using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzaria_Do_Evandro
{
    class CardapioAdapter : BaseAdapter
    {
        private ArrayList items = new ArrayList();
        private Activity context;
        private List<CardapioItem> listaCardapio;

        public CardapioAdapter(Activity context, List<CardapioItem> lista)
        {
            this.context = context;
            listaCardapio = lista;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return listaCardapio[position].ToString();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            CardapioAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as CardapioAdapterViewHolder;

            if (holder == null)
            {
                holder = new CardapioAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                view = inflater.Inflate(Resource.Layout.cardapio_item, parent, false);
                holder.descricao = (TextView)view.FindViewById(Resource.Id.Descricao_Pizza_1);
                holder.imagem = (ImageView)view.FindViewById(Resource.Id.Imagem_Pizza);
                view.Tag = holder;
            }

            holder.descricao.Text = listaCardapio[position].Descricao;
            holder.imagem.SetImageBitmap(listaCardapio[position].Imagem);

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return listaCardapio.Count;
            }
        }

    }

    class CardapioAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
        public TextView descricao { get; set; }
        public ImageView imagem { get; set; }
    }
}