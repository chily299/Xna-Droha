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

    class imagenesm2
    {

        public Texture2D imagen;
        public int id;


    }
    class Malo2
    {
        int imagenactual = 0;
        int vida = 100;
        Vector2 posicion;
        personaje personaje;
        Vector2 origen = Vector2.Zero;
        float scale = 0.3f;
        SpriteEffects efecto = SpriteEffects.None;
        List<imagenesm2> lista = new List<imagenesm2>();



        public Malo2(Vector2 pos, personaje pers)
        {

            posicion = pos;
            personaje = pers;

        }

        public void agregarimagen(Texture2D ima, int id)
        {

            imagenesm2 im = new imagenesm2();
            im.imagen = ima;
            im.id = id;
           
            lista.Add(im);


        }


        public void draw(SpriteBatch batch)
        {
            if (vida > 0)
            {
                if (lista.Count == 0 || imagenactual < 0 || lista.Count < imagenactual) return;

                batch.Draw(lista[imagenactual].imagen, posicion, null, Color.White, 0.0f, origen, new Vector2(scale, scale), efecto, 0.0f);

            }
        }

        int cont = 0;
        int cont2 = 0;
        int cont3 = 0;
        Boolean sw = true;
        Boolean sw2 = true;
        Boolean swmov = true;
        Boolean at1=true,at2=true,at3=true,at4=true;
        
        
        public void update(GameTime gametime)
        {

            cont++;
            if (cont >= 3&& swmov)
            {
                if (sw)
                {
                    imagenactual++;
                    if (imagenactual > 2)
                        sw = false;
                }
                if (!sw)
                {
                    imagenactual--;
                    if (imagenactual < 1)
                        sw = true;
                }

                cont = 0;

            }

            avanza();


            if (!at1 && !at2 && !at3)
            {
                swmov = false;
                ataca();
            }
            

            if (!swmov)
            {

                cont2++;
                if (cont2 >= 54)
                {
                    cont3++;
                    if (!ret) posicion.X -= 5;

                    if (ret) posicion.X += 5;

                    if (cont3 >= 15)
                    {

                        swmov = true;
                        cont3 = 0;
                        cont2 = 0;

                    }

                }

            }

            if (personaje.inicio >= 13 && personaje.fin <= 24 && !at3)
            {

                if (Math.Abs(personaje.posicion.X - posicion.X) < 100 && ret)
                {

                    swmov = false;
                    cont2 = 54;
                    vida -= 1;
                }

                if (Math.Abs(personaje.posicion.X - posicion.X) < 50 && !ret)
                {

                    swmov = false;
                    cont2 = 54;
                    vida -= 1;
                }

            }



        }

        Boolean ret = true;
        public void avanza()
        {

            if (personaje.posicion.X + 30 < posicion.X)
            {

                efecto = SpriteEffects.None;
                posicion.X--;
                at1 = true;
                ret = true;

            }
            else at1 = false;

            if (personaje.posicion.X - 35 > posicion.X)
            {
                efecto = SpriteEffects.FlipHorizontally;
                posicion.X++;
                at2 = true;
                ret = false;

            }
            else at2 = false;

            if (personaje.posicion.Y - 30 < posicion.Y)
            {
                posicion.Y--;
                at3 = true;
            }
            else at3 = false;

            if (personaje.posicion.Y - 30 > posicion.Y)
            {

                posicion.Y++;
                at3 = true;
            }
            else at3 = false;
       }

        public void ataca()
        {

            if (!swmov)
            {

                if (sw2)
                {
                    imagenactual++;
                    if (imagenactual > 9)
                        sw2 = false;
                }
                if (!sw2)
                {
                    imagenactual--;
                    if (imagenactual < 1)
                    {
                        sw2 = true;

                    }
                }
            }
        }




    }
}
