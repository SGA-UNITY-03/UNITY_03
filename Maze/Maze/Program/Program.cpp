#include "framework.h"
#include "Program.h"

#include "../Scene/PaintScene.h"

Program::Program()
{
    Start();
}

Program::~Program()
{
}

void Program::Start()
{
    _scene = make_shared<PaintScene>();
}

void Program::Update()
{
    _scene->Update();
}

void Program::Render(HDC hdc)
{
    _scene->Render(hdc);
}
