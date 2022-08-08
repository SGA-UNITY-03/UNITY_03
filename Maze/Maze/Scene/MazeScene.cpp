#include "framework.h"
#include "MazeScene.h"

MazeScene::MazeScene()
{
	Start();
}

MazeScene::~MazeScene()
{
}

void MazeScene::Start()
{
	_maze = make_shared<MazeObj>();
}

void MazeScene::Update()
{
	_maze->Update();
}

void MazeScene::Render(HDC hdc)
{
	_maze->Render(hdc);
}
