using UnityEngine;
using LJH.Scripts.Player;
using PurpleFlowerCore;

namespace LJH.Scripts.Collide
{
    public static class CollideHandler
    {
        public static void ColliderHandle(string tag1, string tag2, ColliderBase collider1, ColliderBase collider2,bool canExchange=true)
        {
            PFCLog.Info($"碰撞处理:{tag1},{tag2}");
            if (tag1 == "Boundary" && tag2 == "Thorn")
            {
                var thePlayer = (collider2 as Thorn).ThePlayer;
                var originDirection = thePlayer.Direction;
                Vector2 Out_Direction = Vector2.Reflect(originDirection,((Boundary)collider1).NormalDirection);
                thePlayer.Direction = Out_Direction;
                PFCLog.Info("撞墙反弹");
                return;
            }
            
            if (tag1 == "Boundary" && tag2 == "Ass")
            {
                var thePlayer = (collider2 as Ass).ThePlayer;
                var originDirection = thePlayer.Direction;
                Vector2 Out_Direction = Vector2.Reflect(originDirection,((Boundary)collider1).NormalDirection);
                
                thePlayer.Direction = Out_Direction;
                PFCLog.Info("撞墙反弹");
                return;
            }
            
            if (tag1 == "Thorn" && tag2 == "Thorn")
            {
                var thePlayer1 = (collider1 as Thorn).ThePlayer;
                var thePlayer2 = (collider2 as Thorn).ThePlayer;
                (thePlayer1.Direction, thePlayer2.Direction) = (thePlayer2.Direction, thePlayer1.Direction);
                (thePlayer1.CurrentSpeed, thePlayer2.CurrentSpeed) = (thePlayer2.CurrentSpeed, thePlayer1.CurrentSpeed);
                return;
            }

            if (tag1 == "Thorn" && tag2 == "Ass")
            {
                PFCLog.Info("玩家:"+(collider1 as Thorn).ThePlayer.id+"胜利");
                //todo: game over
            }
            
            
            
            
            
            if(canExchange)
                ColliderHandle(tag2,tag1,collider2,collider1,false);
        }
    }
}