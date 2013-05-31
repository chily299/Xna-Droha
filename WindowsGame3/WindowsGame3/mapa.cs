using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame3
{
    class lugar {

        public Vector2 posicion;
        public string nombre;
        public int id;
        

        public lugar(Vector2 pos, int _id, string nom)
        {
            posicion = pos;
            id = _id;
            nombre = nom;
        }
    }

    class mapa 
    {
        public basico cursor;
        public Texture2D fondo;
        List<lugar> lugares = new List<lugar>();
        Vector2 origenSprite,posicion,tamano;
        Boolean visible;
        int lugarActual;
        public SpriteFont fuente;



        public mapa(GraphicsDevice device) {

            origenSprite = new Vector2(0, 0);
            posicion = new Vector2(-300, -300);

            cursor = new basico(device);
            cursor.fin = 2;

            //inicio
            lugares.Add(new lugar(new Vector2(370, 320), 1, "Inicio"));
            //pradera
            lugares.Add(new lugar(new Vector2(570, 340), 2, "Pradera"));
            //camino de piedra
            lugares.Add(new lugar(new Vector2(550, 280), 3, "Camino de Piedra"));
            //cripta
            lugares.Add(new lugar(new Vector2(510, 220), 4, "Cripta"));

        }

        public void draw(SpriteBatch barch)
        {

            if (visible)
            {

                //barch.Draw(fondo, posicion, null, Color.White, 0.0f, origenSprite, 1.0f, SpriteEffects.None, 0.0f);
                barch.Draw(fondo, new Rectangle(0, 0, 800, 500), Color.White);
                cursor.setPosicion(lugares[lugarActual].posicion);
                cursor.draw(barch);
                barch.DrawString(fuente, lugares[lugarActual].nombre, lugares[lugarActual].posicion, Color.Black);

               // cursor.draw(barch);

            }

        }

        public void update(GameTime gameTime)
        {
            cursor.update( gameTime);

        }

        public void mostrarMapa() {
            visible = true;
        }

        public void ocultarMapa() {
            visible = false;
        }

        public Boolean esVisible() {
            return visible;
        }

        public void siguiente() {
            lugarActual++;
        }

        public void anterior()
        {
            lugarActual--;
        }

    }
}
