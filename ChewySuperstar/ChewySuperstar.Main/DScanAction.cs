using EVE.ISXEVE;
using InnerSpaceAPI;

namespace ChewySuperstar.Main
{
    public class DScanAction : EVEAction
    {
        private int defaultAngle = 360;
        private int defaultRange = 2147483647;

        protected override void ExecuteAction()
        {
            var me = new Me();
            var directionalScanner = me.Ship.Scanners.Directional;
            InnerSpace.Echo("Scanners is valid: " + me.Ship.Scanners.IsValid);
           
            InnerSpace.Echo("DScanner is valid: " + directionalScanner.IsValid);
            InnerSpace.Echo("SystemScanner is valid: " + me.Ship.Scanners.System.IsValid);

            if (directionalScanner.IsValid)
            {
                var angle = defaultAngle;
                var range = defaultRange;

                directionalScanner.StartScan(angle, range);
            }

            //var results = directionalScanner.GetScanResults(angle, range);

            //InnerSpaceAPI.InnerSpace.Echo(results.Count.ToString());

            ////foreach (var directionalScannerResult in results)
            ////{
            ////    InnerSpaceAPI.InnerSpace.Echo(directionalScannerResult.Name);
            ////}
        }
    }
}