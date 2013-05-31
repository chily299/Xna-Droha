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
    class personaje : basico
    {
        string nombre;
        int id;
        int vida;
        // estadisticas basicas
        int fuerza;
        int velocidad;
        Boolean direccion;
        Boolean bloquearMovimiento;
        Boolean esperaFinPoder,banderaFinPoder;
        public int poderActual,i;

        public List<poder> poderes = new List<poder>();

        public personaje(GraphicsDevice g) : base(g) {
            inicio = 0;
            fin = 1;
            esperaFinPoder = false;
            poderActual = 0;
            poderes.Add(new poder(g));
            poderes.Add(new poder(g));
            poderes.Add(new poder(g));
            poderes.Add(new poder(g));
        }

        
        public void draw2(SpriteBatch barch)
        {
            draw(barch);
            if (esperaFinPoder)
            {
                for (i = 0; i < poderes.Count; i++)
                {
                    poderes[i].draw(barch); 
                }
                
            }
           // poderes[poderActual].draw(barch); 

        } 


        public void update2(GameTime gameTime)
        {
            update(gameTime);
            poderes[poderActual].update2(gameTime);

            esperaFinPoder = false;
            for (i = 0; i < poderes.Count; i++) {
                if (poderes[i].esActivo()) {
                    esperaFinPoder = true;

                    //si el poder esta equipado se mueve
                    if(poderes[i].esEquipada())
                    poderes[i].setPosicion(this.posicion);
                }
            }
        }

        public void esperar()
        {
            if (!esperaFinPoder){
                inicio = 0;
                fin = 1;
                tiempoActualiza = 0.3f;
            }
        }

        public void caminar() {
            inicio = 1;
            fin = 12;
            tiempoActualiza = 0.1f;
        }

        public void atacar() {
            inicio = 13;
            fin = 24;
            tiempoActualiza = 0.02f;
            esperaFinPoder = true;
        }

        public void agregarPoderes(ContentManager Content)
        {
            Texture2D ima;
            ima = Content.Load<Texture2D>("poder_3_guerrero/0001");
            poderes[0].agregarImagenes(ima, 1);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0002");
            poderes[0].agregarImagenes(ima, 2);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0004");
            poderes[0].agregarImagenes(ima, 3);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0005");
            poderes[0].agregarImagenes(ima, 4);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0007");
            poderes[0].agregarImagenes(ima, 5);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0008");
            poderes[0].agregarImagenes(ima, 6);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0009");
            poderes[0].agregarImagenes(ima, 7);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0010");
            poderes[0].agregarImagenes(ima, 8);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0011");
            poderes[0].agregarImagenes(ima, 9);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0012");
            poderes[0].agregarImagenes(ima, 10);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0014");
            poderes[0].agregarImagenes(ima, 11);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0015");
            poderes[0].agregarImagenes(ima, 12);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0016");
            poderes[0].agregarImagenes(ima, 13);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0017");
            poderes[0].agregarImagenes(ima, 14);
            ima = Content.Load<Texture2D>("poder_3_guerrero/0019");
            poderes[0].agregarImagenes(ima, 15);
            poderes[0].fin = 15;
            poderes[0].tiempoActualiza = 0.05f;
           
        }
        

    }
}
