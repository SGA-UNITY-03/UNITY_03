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
	_block = make_shared<Block>();
	_block->SetPosition({ WIN_WIDTH * 0.5f, WIN_HEIGHT * 0.5f });
}

void MazeScene::Update()
{
	_block->Update();
}

void MazeScene::Render(HDC hdc)
{
	_block->Render(hdc);
}
