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

    class imagenes
    {

        public Texture2D imagen;
        public int id;


    }
    class Malo1
    {
        int imagenactual = 0;
        Vector2 posicion;
        personaje personaje;
        Vector2 origen = Vector2.Zero;
        float scale = 1.0f;
        SpriteEffects efecto = SpriteEffects.None;
        List<imagenes> lista = new List<imagenes>();
        int vida = 100;


        public Malo1( personaje pers)
        {

            posicion = new Vector2(500, -50);
            personaje = pers;

        }


        public void agregarimagen(Texture2D ima, int id)
        {

            imagenes im = new imagenes();
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

        int cont = 0, cont2=0,cont3=0;
        int mov=0;
        Boolean sw = true;
        Boolean sw2 = true;
        Boolean swmov = true;
        Boolean at1 = true, at2 = true, at3 = true, at4 = true;
        public void update(GameTime gametime)
        {
            //alas
            cont++;
            if (cont >= 3 && swmov)
            {
                alas();
                cont = 0;
            }
            ///////////
            mov++;
            if (mov >= 2)
            {
                avanza();
                mov = 0;
            }

            if (!at1 && !at2 && !at3)
            {

                swmov = false;
                ataca();

            }
            
            if (!swmov) {

                cont2++;
                if (cont2 >= 54)
                {
                    cont3++;
                    if (!ret) posicion.X -= 5;
                    
                    if (ret)  posicion.X += 5;

                    if (cont3 >= 15) {

                        swmov = true;
                        cont3 = 0;
                        cont2 = 0;

                    }
                
                }

            
            }


            if (personaje.inicio >= 13 && personaje.fin <= 24 && !at3) {

                if (Math.Abs(personaje.posicion.X - posicion.X) < 50 && ret ) {

                    swmov = false;
                    cont2 = 54;
                    vida -= 1;
                }

                if (Math.Abs(personaje.posicion.X - posicion.X) < 200 && !ret)
                {

                    swmov = false;
                    cont2 = 54;
                    vida -= 1;
                }

            }





        }

        public void alas()
        {


            if (sw)
            {
                imagenactual++;
                if (imagenactual > 9)
                    sw = false;
            }
            if (!sw)
            {
                imagenactual--;
                if (imagenactual < 1)
                    sw = true;
            }

        }

        Boolean ret = true;
        public void avanza()
        {

            if (personaje.posicion.X - 30 < posicion.X)
            {

                efecto = SpriteEffects.None;
                posicion.X--;
                at1 = true;
                ret = true;
            }
            else at1 = false;

            if (personaje.posicion.X > posicion.X + 110)
            {
                efecto = SpriteEffects.FlipHorizontally;
                posicion.X++;
                at2 = true;
                ret = false;

            }
            else at2 = false;

            if (personaje.posicion.Y - 120 < posicion.Y)
            {

                posicion.Y--;
                at3 = true;
            }
            else at3 = false;

            if (personaje.posicion.Y - 120 > posicion.Y)
            {

                posicion.Y++;
               
            }
           



        }


        public void ataca()
        {

            if (!swmov)
            {
                           
                if (sw2)
                {
                    imagenactual++;
                    if (imagenactual > 19)
                        sw2 = false;
                }
                if (!sw2)
                {
                    imagenactual--;
                    if (imagenactual < 11)
                    {
                        sw2 = true;

                    }

                }


            }




        }
    }
}

