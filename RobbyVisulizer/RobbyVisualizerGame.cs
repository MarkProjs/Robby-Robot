﻿using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RobbyTheRobot;

namespace RobbyVisulizer
{
    public class RobbyVisulizerGame : Game
    {
        private Random rnd;
        private int x;
        private int y;
        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        private SpriteFont _scoreFont;
        private double _scoreNum = 0;
        private SpriteFont _moveFont;
        private int _moveNum = 0;
        private SpriteFont _genFont;
        private int _genNum = 0;

        private IRobbyTheRobot _robby;
        private Grid grid;

        private static readonly string filePath = "";
        private string _gen;
        private string[] _robyaction;
        private  int[] _robyActionNum;
        private ContentsOfGrid[,] _gridContent;


        public RobbyVisulizerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _robby = Robby.CreateRobby(1000, 200, 100);
            rnd = new Random();
            x = rnd.Next(0, 10);
            y = rnd.Next(0, 10);

        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.PreferredBackBufferWidth = 500;
            _graphics.ApplyChanges();
            _gridContent = _robby.GenerateRandomTestGrid();
            // this.grid = new RobbyGrid(this, _robyaction[0,0],_robyaction[]);
            for (int i = 0; i < _gridContent.GetLength(0); i++)
            {
                for (int j = 0; j < _gridContent.GetLength(1); j++)
                {
                    
                    if (_gridContent[i, j] is ContentsOfGrid.Can)
                    {
                        this.grid = new CanGrid(this, i, j);
                        Components.Add(this.grid);
                    }
                    else if (_gridContent[i, j] is ContentsOfGrid.Empty)
                    {
                        this.grid = new EmptyGrid(this, i, j);
                        Components.Add(this.grid);
                    }
                }
            }
            Grid robby = new RobbyGrid(this, this.x, this.y);
            Components.Add(robby);
            // Splitter();
            // _robyActionNum = new int[_robyaction.Length];
            // for(int i = 0; i < _robyaction.Length; i++){
            //     _robyActionNum[i] = Int32.Parse(_robyaction[i]);
            // }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // _scoreFont = Content.Load<SpriteFont>("Score");
            // _moveFont = Content.Load<SpriteFont>("Move");
            // _genFont = Content.Load<SpriteFont>("Generation");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //TO DO: THE LOGIC PART

            // _moveNum++;
            // _scoreNum = Robby.ScoreForAllele(_robyActionNum, _gridContent, rnd, ref x, ref y);
            // _genNum = Int32.Parse(_gen);
            // Splitter();
            // _robyActionNum = new int[_robyaction.Length];
            // for(int i = 0; i < _robyaction.Length; i++){
            //     _robyActionNum[i] = Int32.Parse(_robyaction[i]);
            // }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }

        private void Splitter()
        {
            string rootFile = FileReader();
            string[] tmpFile = rootFile.Split(";");
            _gen = tmpFile[3];
            _robyaction = tmpFile[4].Split("-");
            
        }

        //  public static double ScoreForAllele(string move, ContentsOfGrid[,] grid, Random rng, ref int x, ref int y)
        // {
        //     switch (move) // After every movement change roby's location along to grid's cell spritebatch
        //         {
        //             case "0"://move north
        //                 if (move.Equals(ContentsOfGrid.Wall.ToString()))
        //                     return -5;
        //                 y -= 1;
        //                 break;
        //             case "1"://move south
        //                 if (move.Equals(ContentsOfGrid.Wall.ToString()))
        //                     return -5;
        //                 y += 1;
        //                 break;
        //             case "2": //move east
        //                 if (move.Equals(ContentsOfGrid.Wall.ToString()))
        //                     return -5;
        //                 x += 1;
        //                 break;
        //             case "3": //move west
        //                 if (move.Equals(ContentsOfGrid.Wall.ToString()))
        //                     return -5;
        //                 x -= 1;
        //                 break;
        //             case "4": //do nothong
        //                 break;
        //             case "5": //pick up can
        //                 if (grid[x, y] == ContentsOfGrid.Can) //there is a can
        //                 {
        //                     grid[x, y] = ContentsOfGrid.Empty;
        //                     return +10;
        //                 }
        //                 else
        //                     return -1; //penalty for picking up nothing
        //             case "6": //random move
        //                 int num = rng.Next(0, Enum.GetNames(typeof(PossibleMoves)).Length);
        //                 move = num.ToString();
        //                 break;
        //         }
             
        //     return 0;
        // }
        // private void UpdateRobyPosition(PossibleMoves loc)
        // {
        //     switch (loc)
        //     {
        //         case PossibleMoves.North://move north
        //             if (direction.N == ContentsOfGrid.Wall)
        //                 return -5;
        //             y -= 1;
        //             break;
        //         case PossibleMoves.South://move south
        //             if (direction.S == ContentsOfGrid.Wall)
        //                 return -5;
        //             y += 1;
        //             break;
        //         case PossibleMoves.East: //move east
        //             if (direction.E == ContentsOfGrid.Wall)
        //                 return -5;
        //             x += 1;
        //             break;
        //         case PossibleMoves.West: //move west
        //             if (direction.W == ContentsOfGrid.Wall)
        //                 return -5;
        //             x -= 1;
        //             break;
        //         case PossibleMoves.Nothing: //do nothong
        //             break;
        //         case PossibleMoves.PickUp: //pick up can
        //             if (grid[x, y] == ContentsOfGrid.Can) //there is a can
        //             {
        //                 grid[x, y] = ContentsOfGrid.Empty;
        //                 return +10;
        //             }
        //             else
        //                 return -1; //penalty for picking up nothing
        //         case PossibleMoves.Random: //random move
        //             done = false;
        //             int num = rng.Next(0, Enum.GetNames(typeof(PossibleMoves)).Length);
        //             move = (PossibleMoves)num;
        //             break;
        //     }
        // }

        private static string FileReader()
        {
            string chromosomes = String.Empty;
            if (File.Exists(filePath))
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    int lineCounter = 0;

                    while ((chromosomes = file.ReadLine()) != null)
                    {
                        lineCounter++;
                    }

                    file.Close();
                    Console.WriteLine($"File has {lineCounter} lines."); // This is for testing purposes 
                }
            }

            return chromosomes;
        }
    }
}