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
    class imagenAnimacion {

        public Texture2D imagen;
        public int id;
    
    }

    class basico
    {
        Boolean repitiendo, detenido, activo;
        public int inicio = 0, fin = 0;
        float tiempoTotal;
        public float tiempoActualiza = 0.3f;

        public Vector2 posicion;
        List<imagenAnimacion> animacion = new List<imagenAnimacion>();
        Texture2D imagen, imagen2;
        Vector2 origenSprite;
        int ventanaAlto, ventanaAncho;
        public int imagenActual;

        public basico(GraphicsDevice device, Vector2 posi, Texture2D ima1, Texture2D ima2)
        {

            posicion = posi;
            imagen = ima1;
            imagen2 = ima2;
            origenSprite.X = imagen.Width / 2.0f;
            origenSprite.Y = imagen.Height / 2.0f;

            ventanaAlto = device.Viewport.Height;
            ventanaAncho = device.Viewport.Width;
            imagenActual = 0;
            
        }

        public basico(GraphicsDevice device)
        {

            
           

            imagenActual = 0;
            

        }

        public void draw(SpriteBatch barch)
        {
                if(animacion.Count == 0 || imagenActual < 0 || animacion.Count < imagenActual)
                    return;

                barch.Draw(animacion[imagenActual].imagen, posicion, null, Color.White, 0.0f, origenSprite, 1.0f, SpriteEffects.None, 0.0f);

            
        }


        public void update(GameTime gameTime)
        {
            KeyboardState keystate = Keyboard.GetState();
            GamePadState gamepadstate = GamePad.GetState(PlayerIndex.One);

            tiempoTotal += (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (tiempoTotal > tiempoActualiza)
            {
                tiempoTotal = 0.0f;
                imagenActual++;

                if (imagenActual >= fin)
                {
                    imagenActual = inicio;
                }
            }

        }

        public void setPosicion(Vector2 pos) {
            posicion = pos;
        }

        public void agregarImagenes(Texture2D imagen, int id){
            imagenAnimacion im = new imagenAnimacion();
            im.imagen = imagen;
            im.id = id;

            animacion.Add(im);
        
        }

        public void arriba() { posicion.Y -= 5; }
        public void abajo() { posicion.Y += 5; }
        public void derecha() { posicion.X += 5; }
        public void izquierda() { posicion.X -= 5; }
    }
}
