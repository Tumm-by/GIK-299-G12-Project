using System;

namespace TextBaseGame
{
    class Ascii
    {

        public static void MonsterSpawn()
        {
            Random random = new Random();
            int enemies = random.Next(1, 4);
            switch (enemies)
            {
                case 1:
                    Console.Write(@"
                          ,_      _,
                            '.__.'
                       '-,   (__)   ,-'
                         '._ .::. _.'
                           _'(^^)'_
                        _,` `>\/<` `,_
                     `    ,-` )( `-,  `
                          |  /==\  |
                        ,-'  |=-|  '-,
                             )-=(
                             \__/
             ");
                    Console.WriteLine();
                    break;
                case 2:
                    Console.Write(@"

                                ########                        
                        ########################                
                       ##########################                
                     ##############################,            
                     ##############  ######  ######,            
                     ##############  ######  ######,            
                     ##############################,            
                     ##############################,            
                     ##############################,            
                     ##############################,
            ");
                    Console.WriteLine();
                    break;

                case 3:
                    Console.Write(@"
                                !
                               !!
                             !####!
                           !#########!                               
                        !###############!                           
                      !#####__#####__######!                          
                     !##### ||#####||#######!                         
                     !######||#####||#######!                         
                     !######--#####--######!                       
                       !##################!                           
                         !##############!
           ");
                    Console.WriteLine();
                    break;
            }
        }
        public static void CollectKey()
        {
            Console.Write(@"
                   .@@@@@@%%%                                                   
               /@@@&&&&&&&&&%%%@@@                                             
            %@@&%%%&&&   &&&%%%&&&@@@                                          
            %@@@&&%         %%%&&&&&&%%%&&&&&&%%%%&&&&&&&&&&&&&&@@@@@@   
            #&&&&&%         %%%&&&&&&&&&&&&%%%%%%&&&&&&&&&&&   &&&%%%&&&   
            #&&&&&%         %%%&&&&&&&&&&&&%%%%%%&&&&&&&&&&&   &&&%%%&&&   
            (%%&&&&&&&   &&&&&&&&&%%%                 %%%         &&&%%%   
               *%%%&&&&&&&&&&&&%%%                    %%%         %%%%%%   
                   %%%%%%%%%  
           ");
            Console.WriteLine();
        }

        public static void StartGame()
        {
            Console.Write(@"
            .___________________________________.
            ||                                 || 
            ||  WELCOME TO THE TEXTBASED GAME  ||
            ||         D U N G E O N           ||
            ||_________________________________||
            ");
        }
        public static void HowToMoveText()
        {
            Console.Write(@"
            .___________________________________.
            ||                                 || 
            ||          INSTRUCTIONS           ||
            ||                                 ||
            || To move you will have to type!  ||
            ||                                 ||
            ||     TO MOVE UP: go up           ||
            ||     TO MOVE Down: go down       ||
            ||                                 ||
            ||     TO MOVE Right: go right     ||
            ||     TO MOVE Left: go left       ||
            ||     TO OPEN Menu: menu          ||
            ||_________________________________||
            ");
            Console.WriteLine();
        }
        public static void HowToMoveArrow()
        {
            Console.Write(@"
            .___________________________________.
            ||                                 || 
            ||          INSTRUCTIONS           ||
            ||                                 ||
            || To move you will have to type!  ||
            ||                                 ||
            ||          TO MOVE UP: ↑          ||
            ||          TO MOVE Down: ↓        ||
            ||                                 ||
            ||          TO MOVE Right: →       ||
            ||          TO MOVE Left: ←        ||
            ||          TO OPEN Menu: ESCAPE   ||
            ||_________________________________||
            ");
            Console.WriteLine();
        }

        public static void MenuInstruct()
        {
            //Console.Clear();
            //Console.Write(@"
            //.___________________________________.
            //||                                 || 
            //||          INSTRUCTIONS           ||
            //||                                 ||
            //||             Menu                ||
            //||                                 ||
            //||         TO LOAD: load           ||
            //||         TO SAVE: save           ||
            //||         TO EXIT GAME: exit      ||
            //||                                 ||
            //||         TO EXIT MENU: enter     ||
            //||                                 ||
            //||_________________________________||
            //");
            Console.Write(@"
            .___________________________________.
            ||                                 || 
            ||          INSTRUCTIONS           ||
            ||                                 ||
            || To move you will have to type!  ||
            ||                                 ||
            ||          TO MOVE UP: ↑          ||
            ||          TO MOVE Down: ↓        ||
            ||                                 ||
            ||          TO MOVE Right: →       ||
            ||          TO MOVE Left: ←        ||
            ||          TO OPEN Menu: ESCAPE   ||
            ||_________________________________||
            ");
            Console.WriteLine();
        }

        public static void Decision()
        {
            Console.Write(@"
                  .______________________________.
                  ||                            ||
                  ||  ATTACK (A)  ||  FLEE (F)  ||
                  ||____________________________||
                  ");
            Console.WriteLine();
        }

        public static void MonsterEncounter()
        {
            Console.Write(@"
                  .______________________________.
                  ||                            ||
                  || You encountered a monster! ||
                  ||    What will you do?       ||
                  ||____________________________||
                  ");
            Console.WriteLine();
        }

        public static void AllMonsterSlayed()
        {
            Console.Write(@"
            ._____________________________________________.
            ||                                           ||
            ||       You have slain all monsters!        ||
            ||     you have unlocked the achievement:    ||
            ||                                           ||      
            ||       |M O N S T E R  S L A Y E R|        ||
            ||                                           ||  
            ||___________________________________________||
            ");
            Console.WriteLine();
        }

        public static void EndGameWin()
        {
            Console.Write(@"
            .______________________________.
            ||                            ||
            
              C O N G R A T U L A T I O N S
                 YOU SUCESSFULLY ESCAPED 
                    FROM THE DUNGEON
                        \(°Ω°)/
            ||____________________________||
            ");
            Console.WriteLine();
        }

        public static void EndGameLose()
        {
            Console.Write(@"
            .______________________________.
            ||                            ||
            
                    Y O U   D I E D
 
                    
                        \(°Ω°)/
            ||____________________________||
            ");
            Console.WriteLine();
        }

    }
}