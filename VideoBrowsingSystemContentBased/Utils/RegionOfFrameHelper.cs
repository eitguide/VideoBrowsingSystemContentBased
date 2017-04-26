using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBrowsingSystemContentBased.Model;

namespace VideoBrowsingSystemContentBased.Utils
{
    public class RegionOfFrameHelper
    {
        public static List<RegionOfFrame> GetListRegionDotBelongTo(Point dotLocation, float dotRadius, int widthFrame, int heightFrame)
        {
            List<RegionOfFrame> resultListRegionDotBelongTo = new List<RegionOfFrame>();
            float regionWidth = widthFrame / (float)ConfigPCT.PCT_NUMBER_OF_HORIZONTAL_REGION;
            float regionHeight = heightFrame / (float)ConfigPCT.PCT_NUMBER_OF_VERTICAL_REGION;

            // add first region that dot already belong to
            RegionOfFrame firstRegion = new RegionOfFrame();
            firstRegion.X = (int)(dotLocation.X / regionWidth);
            firstRegion.Y = (int)(dotLocation.Y / regionHeight);
            resultListRegionDotBelongTo.Add(firstRegion);

            double distanceFromCercleCentral;
            // check left regions
            if (firstRegion.X > 0)
            {
                #region middle left
                for (int x = firstRegion.X - 1; x >= 0; x--)
                {
                    distanceFromCercleCentral = dotLocation.X - regionWidth * (x + 1);
                    if (ConfigPCT.ACCEPT_REGION_NEAR_EQUAL)
                        distanceFromCercleCentral -= ConfigPCT.THRESHOLD_PIXEL_NEAR_EQUAL_FOR_ACCEPT;
                    if (dotRadius > distanceFromCercleCentral)
                    {
                        RegionOfFrame roi = new RegionOfFrame(x, firstRegion.Y);
                        resultListRegionDotBelongTo.Add(roi);
                    }
                    else
                        break;
                }
                #endregion
                #region top left
                if (firstRegion.Y > 0)
                    for (int y = firstRegion.Y - 1; y >= 0; y--)
                    {
                        for (int x = firstRegion.X - 1; x >= 0; x--)
                        {
                            distanceFromCercleCentral = DistanceHelper.CalDistanceBetween2Points(dotLocation, new Point((int)regionWidth * (x + 1), (int)regionHeight * (y + 1)));
                            if (ConfigPCT.ACCEPT_REGION_NEAR_EQUAL)
                                distanceFromCercleCentral -= ConfigPCT.THRESHOLD_PIXEL_NEAR_EQUAL_FOR_ACCEPT;
                            if (dotRadius > distanceFromCercleCentral)
                            {
                                RegionOfFrame roi = new RegionOfFrame(x, y);
                                resultListRegionDotBelongTo.Add(roi);
                            }
                            else
                                break;
                        }
                    }
                #endregion
                #region bottom left
                if (firstRegion.Y < ConfigPCT.PCT_NUMBER_OF_VERTICAL_REGION - 1)
                    for (int y = firstRegion.Y + 1; y < ConfigPCT.PCT_NUMBER_OF_VERTICAL_REGION; y++)
                    {
                        for (int x = firstRegion.X - 1; x >= 0; x--)
                        {
                            distanceFromCercleCentral = DistanceHelper.CalDistanceBetween2Points(dotLocation, new Point((int)regionWidth * (x + 1), (int)regionHeight * y));
                            if (ConfigPCT.ACCEPT_REGION_NEAR_EQUAL)
                                distanceFromCercleCentral -= ConfigPCT.THRESHOLD_PIXEL_NEAR_EQUAL_FOR_ACCEPT;
                            if (dotRadius > distanceFromCercleCentral)
                            {
                                RegionOfFrame roi = new RegionOfFrame(x, y);
                                resultListRegionDotBelongTo.Add(roi);
                            }
                            else
                                break;
                        }
                    }
                #endregion
            }
            // check right regions
            if (firstRegion.X < ConfigPCT.PCT_NUMBER_OF_HORIZONTAL_REGION - 1)
            {
                #region middle right
                for (int x = firstRegion.X + 1; x < ConfigPCT.PCT_NUMBER_OF_HORIZONTAL_REGION; x++)
                {
                    distanceFromCercleCentral = regionWidth * x - dotLocation.X;
                    if (ConfigPCT.ACCEPT_REGION_NEAR_EQUAL)
                        distanceFromCercleCentral -= ConfigPCT.THRESHOLD_PIXEL_NEAR_EQUAL_FOR_ACCEPT;
                    if (dotRadius > distanceFromCercleCentral)
                    {
                        RegionOfFrame roi = new RegionOfFrame(x, firstRegion.Y);
                        resultListRegionDotBelongTo.Add(roi);
                    }
                    else
                        break;
                }
                #endregion
                #region top right
                if (firstRegion.Y > 0)
                    for (int y = firstRegion.Y - 1; y >= 0; y--)
                    {
                        for (int x = firstRegion.X + 1; x < ConfigPCT.PCT_NUMBER_OF_HORIZONTAL_REGION; x++)
                        {
                            distanceFromCercleCentral = DistanceHelper.CalDistanceBetween2Points(dotLocation, new Point((int)regionWidth * x, (int)regionHeight * (y + 1)));
                            if (ConfigPCT.ACCEPT_REGION_NEAR_EQUAL)
                                distanceFromCercleCentral -= ConfigPCT.THRESHOLD_PIXEL_NEAR_EQUAL_FOR_ACCEPT;
                            if (dotRadius > distanceFromCercleCentral)
                            {
                                RegionOfFrame roi = new RegionOfFrame(x, y);
                                resultListRegionDotBelongTo.Add(roi);
                            }
                            else
                                break;
                        }
                    }
                #endregion
                #region bottom right
                if (firstRegion.Y < ConfigPCT.PCT_NUMBER_OF_VERTICAL_REGION - 1)
                    for (int y = firstRegion.Y + 1; y < ConfigPCT.PCT_NUMBER_OF_VERTICAL_REGION; y++)
                    {
                        for (int x = firstRegion.X + 1; x < ConfigPCT.PCT_NUMBER_OF_HORIZONTAL_REGION; x++)
                        {
                            distanceFromCercleCentral = DistanceHelper.CalDistanceBetween2Points(dotLocation, new Point((int)regionWidth * x, (int)regionHeight * y));
                            if (ConfigPCT.ACCEPT_REGION_NEAR_EQUAL)
                                distanceFromCercleCentral -= ConfigPCT.THRESHOLD_PIXEL_NEAR_EQUAL_FOR_ACCEPT;
                            if (dotRadius > distanceFromCercleCentral)
                            {
                                RegionOfFrame roi = new RegionOfFrame(x, y);
                                resultListRegionDotBelongTo.Add(roi);
                            }
                            else
                                break;
                        }
                    }
                #endregion
            }
            // check middle regions
            #region check and add region at middle top
            if (firstRegion.Y > 0)
                for (int y = firstRegion.Y - 1; y >= 0; y--)
                {
                    distanceFromCercleCentral = dotLocation.Y - regionHeight * (y + 1);
                    if (ConfigPCT.ACCEPT_REGION_NEAR_EQUAL)
                        distanceFromCercleCentral -= ConfigPCT.THRESHOLD_PIXEL_NEAR_EQUAL_FOR_ACCEPT;
                    if (dotRadius > distanceFromCercleCentral)
                    {
                        RegionOfFrame roi = new RegionOfFrame(firstRegion.X, y);
                        resultListRegionDotBelongTo.Add(roi);
                    }
                    else
                        break;
                }
            #endregion
            #region check and add region at middle bottom
            if (firstRegion.Y < ConfigPCT.PCT_NUMBER_OF_VERTICAL_REGION - 1)
                for (int y = firstRegion.Y + 1; y < ConfigPCT.PCT_NUMBER_OF_HORIZONTAL_REGION; y++)
                {
                    distanceFromCercleCentral = regionHeight * y - dotLocation.Y;
                    if (ConfigPCT.ACCEPT_REGION_NEAR_EQUAL)
                        distanceFromCercleCentral -= ConfigPCT.THRESHOLD_PIXEL_NEAR_EQUAL_FOR_ACCEPT;
                    if (dotRadius > distanceFromCercleCentral)
                    {
                        RegionOfFrame roi = new RegionOfFrame(firstRegion.X, y);
                        resultListRegionDotBelongTo.Add(roi);
                    }
                    else
                        break;
                }
            #endregion

            return resultListRegionDotBelongTo;
        }
    }
}
