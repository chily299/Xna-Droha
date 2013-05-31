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
    class fondo
    {
        Random randomizer = new Random();
        Texture2D foregroundTexture, groundTexture, ground, roca,bosque, roca2;
        int screenWidth;
        int screenHeight;
        int[] terrainContour;
        int[] terrainContour2;


        public fondo(ContentManager Content, GraphicsDevice device) {
             bosque = Content.Load<Texture2D>("escenario/bosque");
             ground = Content.Load<Texture2D>("escenario/grass2");
             roca = Content.Load<Texture2D>("escenario/roca");
             roca2 = Content.Load<Texture2D>("escenario/roca2");
             groundTexture = Content.Load<Texture2D>("escenario/grass");
             screenWidth = device.PresentationParameters.BackBufferWidth;
             screenHeight = device.PresentationParameters.BackBufferHeight;
             terrainContour = new int[screenWidth];
             terrainContour2 = new int[screenWidth];
             GenerateTerrainContour(terrainContour, 150, 2,10);
             GenerateTerrainContour(terrainContour2, 350, 6,30);
             CreateForeground(device);
        }

        public void draw(SpriteBatch batch)
        {
            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
          //  batch.Draw(backgroundTexture, screenRectangle, Color.White);
            //batch.Draw(ground, screenRectangle, Color.White);
            batch.Draw(foregroundTexture, screenRectangle, Color.White);
        }

        public void GenerateTerrainContour(int[] terrainContour, float offset, float peakheight, float flatness)
        {
           // terrainContour = new int[screenWidth];

            double rand1 = randomizer.NextDouble() + 1;
            double rand2 = randomizer.NextDouble() + 2;
            double rand3 = randomizer.NextDouble() + 3;

            for (int x = 0; x < screenWidth; x++)
            {
                double height = peakheight / rand1 * Math.Sin((float)x / flatness * rand1 + rand1);
                height += peakheight / rand2 * Math.Sin((float)x / flatness * rand2 + rand2);
                height += peakheight / rand3 * Math.Sin((float)x / flatness * rand3 + rand3);
                height += offset;
                terrainContour[x] = (int)height;
            }
        }

        public void CreateForeground(Texture2D groundTexture, int screenWidth, int screenHeight, GraphicsDevice device)
        {

            Color[,] groundColors = TextureTo2DArray(groundTexture);
            Color[] foregroundColors = new Color[screenWidth * screenHeight];

            for (int x = 0; x < screenWidth; x++)
            {
                for (int y = 0; y < screenHeight; y++)
                {
                   // if (y > terrainContour[x])
                        foregroundColors[x + y * screenWidth] = groundColors[x % groundTexture.Width, y % groundTexture.Height];
                   // else
                     //   foregroundColors[x + y * screenWidth] = Color.Black;
                }
            }

            foregroundTexture = new Texture2D(device, screenWidth, screenHeight, false, SurfaceFormat.Color);
            foregroundTexture.SetData(foregroundColors);
        }

        public void CreateForeground( GraphicsDevice device)
        {
            int r1 = (int)(randomizer.NextDouble()*screenWidth);
            Color[,] groundColors = TextureTo2DArray(groundTexture);
            Color[,] groundColors2 = TextureTo2DArray(ground);
            Color[,] bosqueColors = TextureTo2DArray(bosque);
            Color[,] rocaColors = TextureTo2DArray(roca);
            Color[,] rocaColors2 = TextureTo2DArray(roca2);
            Color[] foregroundColors = new Color[screenWidth * screenHeight];

            for (int x = 0; x < screenWidth; x++)
            {
                for (int y = 0; y < screenHeight; y++)
                {
                    if (y > terrainContour[x] && y< terrainContour2[x])
                        foregroundColors[x + y * screenWidth] = groundColors[(x+r1) % groundTexture.Width, (y+r1) % groundTexture.Height];
                    else if (y == terrainContour[x])
                        foregroundColors[x + y * screenWidth] = Color.SaddleBrown;
                    else if ( y == terrainContour2[x])
                        foregroundColors[x + y * screenWidth] = Color.DarkGreen;
                    else if (y < terrainContour[x])
                        foregroundColors[x + y * screenWidth] = bosqueColors[(x+r1) % bosque.Width, (y+10) % bosque.Height];
                    else if(y> terrainContour2[x])
                        foregroundColors[x + y * screenWidth] = groundColors2[(x+r1) % ground.Width, (y+r1) % ground.Height];         
                
                }
            }


            int auxy, aux;

            for (int x = 0; x < 8; x++)
            {
                
                    auxy = (int)(randomizer.NextDouble()*180)+150;
                    aux = (int)(randomizer.NextDouble() * (screenWidth - 100))+50;


                    for (int h = 0; h < roca.Width; h++)
                    {
                        for (int k = 0; k < roca.Height; k++)
                        {
                            if (rocaColors[h,k]!=Color.Transparent)
                                foregroundColors[(aux + h) + (auxy + k) * screenWidth] = rocaColors[h,k];
                            //else
                            //  foregroundColors[x + y * screenWidth] = Color.Black;
                        }
                    }
                
            }

            for (int x = 0; x < 15; x++)
            {

                auxy = (int)(randomizer.NextDouble() * 180) + 150;
                aux = (int)(randomizer.NextDouble() * (screenWidth - 10));


                for (int h = 0; h < roca2.Width; h++)
                {
                    for (int k = 0; k < roca2.Height; k++)
                    {
                        if (rocaColors2[h, k] != Color.Transparent)
                            foregroundColors[(aux + h) + (auxy + k) * screenWidth] = rocaColors2[h, k];
                        //else
                        //  foregroundColors[x + y * screenWidth] = Color.Black;
                    }
                }

            }

            foregroundTexture = new Texture2D(device, screenWidth, screenHeight, false, SurfaceFormat.Color);
            foregroundTexture.SetData(foregroundColors);
        }

        private Color[,] TextureTo2DArray(Texture2D texture)
        {
            Color[] colors1D = new Color[texture.Width * texture.Height];
            texture.GetData(colors1D);

            Color[,] colors2D = new Color[texture.Width, texture.Height];
            for (int x = 0; x < texture.Width; x++)
                for (int y = 0; y < texture.Height; y++)
                    colors2D[x, y] = colors1D[x + y * texture.Width];

            return colors2D;
        }
    }
}
