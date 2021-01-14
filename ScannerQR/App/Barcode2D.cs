using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Com.Barcode;
using Android.Media;

namespace BarCode2D_Receiver
{
   public class Barcode2D
    {
        String TAG = "Barcode2D";
        BarcodeUtility barcodeUtility = null;
        BarcodeDataReceiver barcodeDataReceiver = null;
        IBarcodeResult iBarcodeResult = null;
      
        public Barcode2D()
        {
            barcodeUtility = BarcodeUtility.Instance;//.getInstance();
        }
        //开始扫码
        public void startScan(Context context)
        {
            if (barcodeUtility != null)
            {
                
               // Debug..i(TAG, "ScanBarcode");
                barcodeUtility.StartScan(context, BarcodeUtility.ModuleType.Barcode2d);
            }
        }

        //开始和停止扫描
        public void EnableTrigger(Context context,bool enable)
        {
            if (barcodeUtility != null)
            {
                if (enable)
                    barcodeUtility.StartScan(context, BarcodeUtility.ModuleType.Barcode2d);
                else
                {
                    barcodeUtility.StopScan(context, BarcodeUtility.ModuleType.Barcode2d);
                    EnableKeyboardemulator(context, false);

                }
            }
        }
        //开关键盘助手总开关
        public void EnableKeyboardemulator(Context context,bool enable)
        {
            if (barcodeUtility != null)
            {
                if (enable)
                    barcodeUtility.OpenKeyboardHelper(context);
                else
                    barcodeUtility.CloseKeyboardHelper(context);
            }
        }
        //是否播放声音
        public void GoodReadNotificationSound(Context context,bool enable)
        {
            if (barcodeUtility != null)
            {
                if (enable)
                    barcodeUtility.EnablePlaySuccessSound(context, true);
                else
                    barcodeUtility.EnablePlaySuccessSound(context, false);
            }
        }


        //停止扫描
        public void stopScan(Context context)
        {
            if (barcodeUtility != null)
            {
               // Log.i(TAG, "stopScan");
                barcodeUtility.StopScan(context, BarcodeUtility.ModuleType.Barcode2d);
            }
        }

        //打开
        public void open(Context context, IBarcodeResult iBarcodeResult)
        {
            if (barcodeUtility != null)
            {
                this.iBarcodeResult = iBarcodeResult;
                barcodeUtility.SetOutputMode(context, 2);//设置广播接收数据
                barcodeUtility.SetScanResultBroadcast(context, "com.scanner.broadcast", "data");//设置接收数据的广播
                barcodeUtility.Open(context, BarcodeUtility.ModuleType.Barcode2d);//打开2D
                barcodeUtility.SetReleaseScan(context, true);//设置松开扫描按键，不停止扫描
                barcodeUtility.SetScanFailureBroadcast(context, true);//扫描失败也发送广播
                barcodeUtility.EnableContinuousScan(context, false);//关闭键盘助手连续扫描
                barcodeUtility.EnablePlayFailureSound(context, false);//关闭键盘助手 扫描失败的声音
                barcodeUtility.EnablePlaySuccessSound(context, false);//关闭键盘助手 扫描成功的声音
                barcodeUtility.EnableEnter(context, false);//关闭回车

              
                if (barcodeDataReceiver == null)
                {
                    barcodeDataReceiver = new BarcodeDataReceiver(this.iBarcodeResult);
                    IntentFilter intentFilter = new IntentFilter();
                    intentFilter.AddAction("com.scanner.broadcast");
                    context.RegisterReceiver(barcodeDataReceiver, intentFilter);
                }
            }
        }
        //关闭
        public void close(Context context)
        {
            if (barcodeUtility != null)
            {
                barcodeUtility.Close(context, BarcodeUtility.ModuleType.Barcode2d);//关闭2D
                if (barcodeDataReceiver != null)
                {
                    context.UnregisterReceiver(barcodeDataReceiver);
                    barcodeDataReceiver = null;
                }
            }
        }
                   

    }



    class BarcodeDataReceiver : BroadcastReceiver
    {
        IBarcodeResult ib;
        public BarcodeDataReceiver(IBarcodeResult IB)
        {
            ib = IB;
        }
        public override void OnReceive(Context context, Intent intent)
        {

            String barCode = intent.GetStringExtra("data");
            String status = intent.GetStringExtra("SCAN_STATE");
            if (status != null && (status.Equals("cancel")))
            {
                //cancel 表示键盘助手没有执行扫描操作，这个结果不作为返回值
                return;
            }
            else
            {
                if (barCode != null && !barCode.Equals(""))
                {
                    //success
                }
                else
                {
                    barCode = "Scan fail";
                    //fail
                }
                if (ib != null)
                    ib.GetBarcode(barCode);
            }


            //String barCode = intent.GetStringExtra("data");
            //if (!string.IsNullOrEmpty(barCode))
            //{
            //    // success tvData.setText(barCode);
            //}
            //else
            //{
            //    barCode = "Scan fail";
            //    //fail  tvData.setText("Scan fail");
            //}
            //if (ib != null)
            // ib.GetBarcode(barCode);

            
        }


    }
}