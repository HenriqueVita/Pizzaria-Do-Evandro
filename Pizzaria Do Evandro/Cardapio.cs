using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace Pizzaria_Do_Evandro
{
    [Activity(Name = "Pizzaria_Do_Evandro.Cardapio", MainLauncher = false)]
    public class Cardapio : Activity
    {
        private MySqlConnection con;
        private MySqlConnectionStringBuilder sqlConnectionStringbuilder;
        ListView listCardapio;
        CardapioAdapter cardapioAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.cardapio);
            // Setting header
            TextView textView = new TextView(this);
            textView.SetTypeface(Typeface.DefaultBold, TypefaceStyle.Bold);
            textView.Text = "CARDAPIO";

            listCardapio = (ListView)FindViewById(Resource.Id.listaCardapio);
            listCardapio.AddHeaderView(textView);
        }

        protected override void OnStart()
        {
            base.OnStart();
            try
            {
                sqlConnectionStringbuilder = new MySqlConnectionStringBuilder { Server = "50.62.149.29", UserID = "i7481907_ab1", Password = "7777vvvv", Database = "i7481907_ab1", };
                con = new MySqlConnection(sqlConnectionStringbuilder.ConnectionString);
                UpdateListView();
            }
            catch (Exception)
            {

                throw;
            }
            finally { 
                con.Close(); 
            }
            
        }

        private void UpdateListView() { 
            byte[] byteArray;
            List<CardapioItem> cardapio;
            MySqlDataReader reader;
            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                cardapio = new List<CardapioItem>();
                var cmd = new MySqlCommand("SELECT * FROM Produto", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    byteArray = (byte[])reader.GetValue(reader.GetOrdinal("imagem"));
                    cardapio.Add(new CardapioItem(reader.GetString(reader.GetOrdinal("descricao")), BitmapFactory.DecodeByteArray(byteArray, 0, byteArray.Length)));
                };
                cardapioAdapter = new CardapioAdapter(this, cardapio);

                // For populating list data
                listCardapio.Adapter = cardapioAdapter;
                cardapioAdapter.NotifyDataSetChanged();
            }
        }

        public void onPizzaClick(EventArgs[] args) {
        }
}
        
}