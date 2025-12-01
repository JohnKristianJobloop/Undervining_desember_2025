using System;

namespace Kodestil_Kodestandarder.Models;

public class HeadPhoneAmp
{
    public string ManufactorerName {get;set;}

    private int _secretManufactorerId;

    public void PlayMusic(){}

    private void _validateManufactorerId(){}

    public bool IsEven(int number)
    {
        return number switch
        {
            0 => true,
            1 => false,
            2 => true,
            3 => false,
            4 => true,
            5 => false
        };
    }

    public void WriteOutNumberOfTimesThisHasBeenCalledPlussManufacturerName()
    {
        var incrementor = _secretManufactorerId;

        
    }

}
