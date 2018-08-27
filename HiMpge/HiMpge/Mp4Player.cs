using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiMpge.Data;
using HiMpge.HI;

namespace HiMpge
{
    public partial class Mp4Player : Form
    {
        private hi_h264dec.hiH264_DEC_ATTR_S decAttr;
        private IntPtr _decHandle;
        private byte[] data;

        #region Constructor
        public Mp4Player()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void Mp4Player_Load(object sender, EventArgs e)
        {
            InitDecoder();
            data = FrameProvider.GetH264FileData();
        }
        #endregion

        #region FormClosing
        private void Mp4Player_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyDecoder();
        }
        #endregion

        #region InteractionEvent

        #region DecodeFrameClick
        private void DecodeFrame_Click(object sender, EventArgs e)
        {
            DecodeFullyFrame();
        }
        #endregion

        #endregion

        #region InitDecoder
        private void InitDecoder()
        {
            decAttr = new hi_h264dec.hiH264_DEC_ATTR_S();
            decAttr.uPictureFormat = 0;
            decAttr.uStreamInType = 0;
            decAttr.uPicWidthInMB = 480 >> 4;
            decAttr.uPicHeightInMB = 640 >> 4;
            decAttr.uBufNum = 8;
            decAttr.uWorkMode = 16;
            _decHandle = hi_h264dec.Hi264DecCreate(ref decAttr);
        }
        #endregion

        #region DestroyDecoder
        private void DestroyDecoder()
        {
            hi_h264dec.Hi264DecDestroy(_decHandle);
        }
        #endregion

        #region DecodeFrame
        private void DecodeFullyFrame()
        {
            try
            {
                var _decodeFrame = new hi_h264dec.hiH264_DEC_FRAME_S();

                //pData 为需要解码的 H264 nalu 数据，length 为该数据的长度
                IntPtr pData = Marshal.AllocCoTaskMem(data.Length);
                Marshal.Copy(data, 0, pData, data.Length);
                uint length = (uint)data.Length;

                var resCode = hi_h264dec.Hi264DecFrame(_decHandle, pData, length, 0, ref _decodeFrame, 0);
                while (resCode != hi_h264dec.HI_H264DEC_NEED_MORE_BITS)
                {
                    if (resCode == hi_h264dec.HI_H264DEC_OK)
                    {
                        if (_decodeFrame.bError == 0)
                        {
                            //计算y u v长度
                            var yLength = _decodeFrame.uHeight + _decodeFrame.uYStride;
                            var uLength = _decodeFrame.uHeight + _decodeFrame.uUVStride / 2;
                            var vLength = uLength;

                            var yBytes = new byte[yLength];
                            var uBytes = new byte[uLength];
                            var vBytes = new byte[vLength];
                            var decodedBytes = new byte[yLength + uLength + vLength];

                            //_decodeFrame 是解码后的数据对象
                            Marshal.Copy(_decodeFrame.pY, yBytes, 0, (int)yLength);
                            Marshal.Copy(_decodeFrame.pU, uBytes, 0, (int)uLength);
                            Marshal.Copy(_decodeFrame.pV, vBytes, 0, (int)vLength);

                            //数据放入 decodedBytes 中
                            Array.Copy(yBytes, decodedBytes, yLength);
                            Array.Copy(uBytes, 0, decodedBytes, yLength, uLength);
                            Array.Copy(vBytes, 0, decodedBytes, yLength + vLength, vLength);

                            //Show yuv Picture
                            
                        }
                    }
                    resCode = hi_h264dec.Hi264DecFrame(_decHandle, IntPtr.Zero, length, 0, ref _decodeFrame, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
    }
}
