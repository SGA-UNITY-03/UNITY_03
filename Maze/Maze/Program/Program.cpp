#include "framework.h"
#include "Program.h"

#include "../Scene/PaintScene.h"
#include "../Scene/MazeScene.h"

HDC Program::_backBuffer = nullptr;

Program::Program()
{
    Start();

    HDC hdc = GetDC(hWnd);

    _backBuffer = CreateCompatibleDC(hdc);
    _hBit = CreateCompatibleBitmap(hdc, WIN_WIDTH, WIN_HEIGHT);
    SelectObject(_backBuffer, _hBit);

    ReleaseDC(hWnd, hdc);
}

Program::~Program()
{
    DeleteObject(_hBit);
    DeleteObject(_backBuffer);
}

void Program::Start()
{
    srand(static_cast<unsigned int>(time(nullptr)));
    _scene = make_shared<MazeScene>();
}

void Program::Update()
{
    _scene->Update();
}

void Program::Render(HDC hdc)
{
    PatBlt(_backBuffer, 0, 0, WIN_WIDTH, WIN_HEIGHT, BLACKNESS);

    _scene->Render(_backBuffer);

    BitBlt
    (
        // 목적지
        hdc, 0, 0, WIN_WIDTH, WIN_HEIGHT,
        // 복사할 정보
        _backBuffer, 0, 0, SRCCOPY
    );
}
