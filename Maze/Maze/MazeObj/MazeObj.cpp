#include "framework.h"
#include "MazeObj.h"

MazeObj::MazeObj()
{
	float offsetX = CENTER_X - 200;
	float offsetY = CENTER_Y - 230;

	for (int y = 0; y < _poolCountY; y++)
	{
		for (int x = 0; x < _poolCountX; x++)
		{
			shared_ptr<Block> block = make_shared<Block>();
			block->SetPosition({ 19 * x + offsetX, 19 * y + offsetY });
			_blocks.push_back(block);
			_blockMatrix[x][y] = block;
		}
	}

	CreateMaze();

	_player = make_shared<Player>(make_shared<MazeObj>(*this));
	_player->SetPos(GetStartPos());
}

MazeObj::~MazeObj()
{
}

void MazeObj::Update()
{
	for (auto& block : _blocks)
		block->Update();

	_player->Update();

	// �÷��̾� ��ġ�� �ش��ϴ� ��� �� �ٲٱ�
	_blockMatrix[(UINT)(_player->GetPos()._x)][(UINT)_player->GetPos()._y]->SetType(BlockType::PLAYER);
}

void MazeObj::Render(HDC hdc)
{
	for (auto& block : _blocks)
		block->Render(hdc);
}

// ��ó
// mazes for programmers
void MazeObj::CreateMaze()
{
	for (int y = 0; y < _poolCountY; y++)
	{
		for (int x = 0; x < _poolCountX; x++)
		{
			if (x % 2 == 0 || y % 2 == 0)
				_blockMatrix[x][y]->SetType(BlockType::DISABLE);

			else
				_blockMatrix[x][y]->SetType(BlockType::ABLE);
		}
	}

	// �������� ���� Ȥ�� �Ʒ��� ���� �մ� �۾�
	for (int y = 0; y < _poolCountY; y++)
	{
		for (int x = 0; x < _poolCountX; x++)
		{
			if (x % 2 == 0 || y % 2 == 0)
				continue;

			// ������
			if (x == _poolCountX - 2 && y == _poolCountY - 2)
			{
				_blockMatrix[x][y]->SetType(BlockType::END);
				continue;
			}

			if (x == _poolCountX - 2)
			{
				_blockMatrix[x][y + 1]->SetType(BlockType::ABLE);
				continue;
			}

			if (y == _poolCountY - 2)
			{
				_blockMatrix[x + 1][y]->SetType(BlockType::ABLE);
				continue;
			}

			const int randValue = rand() % 2;
			if (randValue == 0)
				_blockMatrix[x + 1][y]->SetType(BlockType::ABLE);
			else
				_blockMatrix[x][y + 1]->SetType(BlockType::ABLE);
		}
	}
}
