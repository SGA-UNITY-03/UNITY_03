#include "framework.h"
#include "PaintScene.h"

PaintScene::PaintScene()
{
    Start();
}

PaintScene::~PaintScene()
{
}

void PaintScene::Start()
{
    _brush = CreateSolidBrush(RGB(255, 0, 0));
    _pen = CreatePen(PS_SOLID, 3, RGB(0, 255, 0));
}

void PaintScene::Update()
{
}

void PaintScene::Render(HDC hdc)
{
    SelectObject(hdc, _brush);
    Ellipse(hdc, 0, 0, 100, 100);
    Rectangle(hdc, 100, 100, 200, 200);

    SelectObject(hdc, _pen);
    MoveToEx(hdc, 0, 0, nullptr);
    LineTo(hdc, 500, 500);
}
