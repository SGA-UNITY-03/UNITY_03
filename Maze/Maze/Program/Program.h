#pragma once
class Program
{
public:
	Program();
	~Program();

	void Start();
	void Update();
	void Render(HDC hdc);

private:
	shared_ptr<Scene> _scene;
};

