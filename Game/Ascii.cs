using System;

namespace TextBaseGame
{
    class Ascii
    {

        public static void Ant()
        {
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




        }
        public static void Slime()
        {
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

        }
        public static void Water()
        {
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

        public static void MoreMonster()
        {
            Console.Write(@"
            .______________________________.
            ||                            ||
            ||   Another one appeared!    ||
            ||____________________________||

            ");
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