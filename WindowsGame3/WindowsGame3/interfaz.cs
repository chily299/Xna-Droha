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
    class interfaz
    {
        Texture2D vida, empunadura,filoprofundo, filosuperficial, exp, lvl, skill1, skill2, skill3, skill4, set, set1a, set1d, set2a, set2d, setseparador;
        Texture2D[] numeros ;
        
        public interfaz(ContentManager content) {

            numeros = new Texture2D [10];
            for (int i = 0; i < 10; i++ )
                numeros[i] = content.Load<Texture2D>("interfaz/"+i+"");

            vida = content.Load<Texture2D>("interfaz/vida");
            empunadura = content.Load<Texture2D>("interfaz/empunadura");
            filoprofundo = content.Load<Texture2D>("interfaz/filoprofundo");
            filosuperficial = content.Load<Texture2D>("interfaz/filosuperficial");
            exp = content.Load<Texture2D>("interfaz/experiencia");
            lvl = content.Load<Texture2D>("interfaz/lvl");
            skill1=content.Load<Texture2D>("interfaz/skill1");
            skill2 = content.Load<Texture2D>("interfaz/skill2");
            skill3 = content.Load<Texture2D>("interfaz/skill3");
            skill4 = content.Load<Texture2D>("interfaz/skill4");
            set = content.Load<Texture2D>("interfaz/set");
            set1a = content.Load<Texture2D>("interfaz/set1a");
            set1d = content.Load<Texture2D>("interfaz/set1d");
            set2a = content.Load<Texture2D>("interfaz/set2a");
            set2d = content.Load<Texture2D>("interfaz/set2d");
            setseparador = content.Load<Texture2D>("interfaz/setseparador");
        }

        public void draw(SpriteBatch batch){
            
            //validacion vida
            batch.Draw(vida, new Vector2(-5, -45), Color.White); 
            //

            batch.Draw(empunadura, new Vector2(-5, -45), Color.White);
            batch.Draw(filoprofundo, new Vector2(77, 367), Color.White);
            
            //validacion exp
            batch.Draw(exp, new Vector2(20, 360), Color.White);
            //
            
            batch.Draw(filosuperficial, new Vector2(77, 367), Color.White);
            batch.Draw(set, new Vector2(0, 332), Color.White);
            batch.Draw(setseparador, new Vector2(-5,355), Color.White);
            
            //validacion set activo
            batch.Draw(set1a, new Vector2(10, 355), Color.White);
            batch.Draw(set2d, new Vector2(65, 390), Color.White);
            //
            
            batch.Draw(lvl, new Vector2(110, 398), Color.White);
            
            //validacion lvl
            batch.Draw(numeros[4], new Vector2(140, 398), Color.White);
            batch.Draw(numeros[9], new Vector2(150, 398), Color.White);
            //

            batch.Draw(skill1, new Vector2(200, 380), Color.White);
            batch.Draw(skill2, new Vector2(300, 380), Color.White);
            batch.Draw(skill3, new Vector2(400, 380), Color.White);
            batch.Draw(skill4, new Vector2(500, 380), Color.White);
        }
    }
}
