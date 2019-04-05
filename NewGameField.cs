using System;
namespace FinalBattleship
{
    public interface NewGameField
    {
        char getIcon();
        Result shootAt();
    }
}
