#pragma once
class MazeScene : public Scene
{
public:
	MazeScene();
	virtual ~MazeScene();

	virtual void Start() override;
	virtual void Update() override;
	virtual void Render(HDC hdc) override;

private:
	//vector<shared_ptr<Block>> _blocks;
	shared_ptr<Block> _block;
};

