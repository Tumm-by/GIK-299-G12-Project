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
        public static void HowToMove()
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
            ||_________________________________||
            ");
        }
        public static void Decision()
        {
            Console.Write(@"
            .______________________________.
            ||                            ||
            ||  ATTACK (A)  ||  FLEE (F)  ||
            ||____________________________||
            ");
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
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
        }

        public static void EndGame()
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
        }

    }
}