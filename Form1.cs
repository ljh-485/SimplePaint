using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace SimplePaint
{
    public partial class Form1 : Form
    {
        enum ToolType { Line, Rectangle, Circle }  // 사용할도형타입
        private Bitmap canvasBitmap;          // 실제그림이저장되는비트맵
        private Graphics canvasGraphics;      // 비트맵위에그리기위한객체
        private bool isDrawing = false;       // 현재드래그중인지여부
        private Point startPoint;             // 드래그시작점
        private Point endPoint;               // 드래그끝점
        private ToolType currentTool = ToolType.Line;  // 현재선택된도형
        private Color currentColor = Color.Black;      // 현재색상
        private int currentLineWidth = 2;              // 현재선두께
        private float zoomFactor = 1.0f;               // 현재줌배율

        public Form1()
        {
            InitializeComponent();
            // 캔버스초기화
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);   // 캔버스를흰색으로초기화
            picCanvas.Image = canvasBitmap;   // 그린그림을화면(PictureBox)에표시
            // 마우스이벤트연결
            picCanvas.MouseDown += PicCanvas_MouseDown;
            picCanvas.MouseMove += PicCanvas_MouseMove;
            picCanvas.MouseUp += PicCanvas_MouseUp;
            // picCanvas가다시그려질때PicCanvas_Paint함수를실행하도록연결
            picCanvas.Paint += PicCanvas_Paint;
            // 도형선택버튼이벤트연결
            btnLine.Click += btnLine_Click;
            btnRactangle.Click += btnRectangle_Click;
            btnCircle.Click += btnCircle_Click;
            // 색상콤보박스이벤트연결
            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;
            cmbColor.SelectedIndex = 0;  // 기본값: Black
            // 선두께트랙바이벤트연결
            trbLineWidth.Minimum = 1;    // 최소값
            trbLineWidth.Maximum = 10;   // 최대값
            trbLineWidth.Value = 2;
            trbLineWidth.ValueChanged += trbLineWidth_ValueChanged;
            // 파일버튼이벤트연결
            btnOpenFile.Click += btnOpenFile_Click;
            // btnSaveFile은 Designer에서 이미 연결됨
            // 줌버튼이벤트연결
            btnZoomIn.Click += btnZoomIn_Click;
            btnZoomOut.Click += btnZoomOut_Click;
            btnZoomReset.Click += btnZoomReset_Click;
        }

        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;             // 드래그시작
            // 줌 배율을 고려한 실제 좌표 계산
            startPoint = new Point(
                (int)(e.Location.X / zoomFactor),
                (int)(e.Location.Y / zoomFactor)
            );
        }

        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;       // 그림그리기와상관없는마우스움직임은무시
            // 줌 배율을 고려한 실제 좌표 계산
            endPoint = new Point(
                (int)(e.Location.X / zoomFactor),
                (int)(e.Location.Y / zoomFactor)
            );
            // picCanvas를다시그려라(Paint 이벤트를발생시킨다)
            picCanvas.Invalidate();       // 화면다시그리기(미리보기)
        }
        
        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;     // 그림그리기와상관없는마우스움직임은무시
            isDrawing = false;          // 드래그종료
            // 줌 배율을 고려한 실제 좌표 계산
            endPoint = new Point(
                (int)(e.Location.X / zoomFactor),
                (int)(e.Location.Y / zoomFactor)
            );
            // 실제비트맵에도형그리기(확정)
            using (Pen pen = new Pen(currentColor, currentLineWidth))
            {
                DrawShape(canvasGraphics, pen, startPoint, endPoint);
            }
            picCanvas.Invalidate();     // 다시그려서결과반영, Paint 이벤트발생
        }

        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!isDrawing) return;
            // 줌 배율 적용
            e.Graphics.ScaleTransform(zoomFactor, zoomFactor);
            // 점선펜(미리보기용)
            using (Pen previewPen = new Pen(currentColor, currentLineWidth))
            {
                previewPen.DashStyle = DashStyle.Dash;
                DrawShape(e.Graphics, previewPen, startPoint, endPoint);
            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Line;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Rectangle;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Circle;
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColor.SelectedIndex)
            {
                case 0: // Black 검정
                    currentColor = Color.Black;
                    break;
                case 1: // Red 빨강
                    currentColor = Color.Red;
                    break;
                case 2: // Blue 파랑
                    currentColor = Color.Blue;
                    break;
                case 3: // Green 녹색
                    currentColor = Color.Green;
                    break;
                default:
                    currentColor = Color.Black;
                    break;
            }
        }

        private void trbLineWidth_ValueChanged(object sender, EventArgs e)
        {
            currentLineWidth = trbLineWidth.Value;
        }

        private void DrawShape(Graphics g, Pen pen, Point p1, Point p2)
        {
            Rectangle rect = GetRectangle(p1, p2);
            switch (currentTool)
            {
                case ToolType.Line:
                    g.DrawLine(pen, p1, p2);
                    break;
                case ToolType.Rectangle:
                    g.DrawRectangle(pen, rect);
                    break;
                case ToolType.Circle:
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y)
            );
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "이미지 파일|*.png";
                saveDialog.Title = "그림 저장 (PNG, JPG, BMP 3가지 포맷으로 저장됨)";
                saveDialog.FileName = "내그림";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // 확장자 제거하고 기본 파일 경로 얻기
                    string filePath = saveDialog.FileName;
                    string directory = System.IO.Path.GetDirectoryName(filePath);
                    string fileNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(filePath);
                    string basePath = System.IO.Path.Combine(directory, fileNameWithoutExt);

                    try
                    {
                        // PNG로 저장
                        canvasBitmap.Save(basePath + ".png", ImageFormat.Png);

                        // JPG로 저장
                        canvasBitmap.Save(basePath + ".jpg", ImageFormat.Jpeg);

                        // BMP로 저장
                        canvasBitmap.Save(basePath + ".bmp", ImageFormat.Bmp);

                        MessageBox.Show($"저장 완료!\n\n{fileNameWithoutExt}.png\n{fileNameWithoutExt}.jpg\n{fileNameWithoutExt}.bmp", 
                                      "저장 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"저장 실패: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "이미지 파일|*.png;*.jpg;*.jpeg;*.bmp;*.gif|모든 파일|*.*";
                openDialog.Title = "이미지 열기";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 기존 리소스 해제
                        if (canvasGraphics != null)
                        {
                            canvasGraphics.Dispose();
                        }

                        // 이미지 파일 로드
                        Bitmap loadedImage = new Bitmap(openDialog.FileName);

                        // 새 비트맵 생성 (로드된 이미지 크기로)
                        canvasBitmap = new Bitmap(loadedImage.Width, loadedImage.Height);
                        canvasGraphics = Graphics.FromImage(canvasBitmap);

                        // 로드된 이미지를 캔버스에 그리기
                        canvasGraphics.DrawImage(loadedImage, 0, 0);
                        loadedImage.Dispose();

                        // 줌 초기화
                        zoomFactor = 1.0f;
                        ApplyZoom();

                        MessageBox.Show("이미지를 불러왔습니다!", "열기 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"이미지 열기 실패: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (zoomFactor < 5.0f)  // 최대 500%
            {
                zoomFactor += 0.25f;
                ApplyZoom();
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (zoomFactor > 0.25f)  // 최소 25%
            {
                zoomFactor -= 0.25f;
                ApplyZoom();
            }
        }

        private void btnZoomReset_Click(object sender, EventArgs e)
        {
            zoomFactor = 1.0f;
            ApplyZoom();
        }

        private void ApplyZoom()
        {
            if (canvasBitmap != null)
            {
                // PictureBox 크기를 줌 배율에 맞춰 조정
                picCanvas.Width = (int)(canvasBitmap.Width * zoomFactor);
                picCanvas.Height = (int)(canvasBitmap.Height * zoomFactor);
                picCanvas.Image = canvasBitmap;

                // 줌 레이블 업데이트
                lblZoom.Text = $"{(int)(zoomFactor * 100)}%";
                btnZoomReset.Text = $"{(int)(zoomFactor * 100)}%";
            }
        }
    }
}
