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
    class poder : basico
    {
        Boolean Activo;
        Boolean Visible;
        int duracion;
        Boolean poderEquipado;

        public poder(GraphicsDevice g) : base(g) {
            Activo = false;
            imagenActual = 1;
            poderEquipado = true;
        }

        public Boolean esActivo() {
            return Activo;
        }
        public Boolean esEquipada() {
            return poderEquipado;
        }
        

        public void update2(GameTime gameTime) {
            if (imagenActual == fin-1)
            {
                Activo = false;
                imagenActual = 0;
            }

            if(Activo )
            this.update(gameTime);


            //poderes de area no se actualiza la posicion

            //poderes equipados

        }

        public void ejecutar() {
            Activo = true;
        
        }
    }
}
