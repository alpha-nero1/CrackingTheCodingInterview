#include <iostream>
#include <iomanip>
#include <locale>

using namespace std;

class Piece
{
    public:
        int is_black;
        bool is_placed;

        Piece(bool is_black)
        {
            this->is_black = is_black;
        }
};

class Board
{
    public:
        Board(int width, int height)
        {
            this->width = width;
            this->height = height;
        }

        void place_piece(int x, int y, int is_black)
        {
            if (&this->board[x][y] != nullptr)
            {
                runtime_error("Cannot place a piece here");
            }
            Piece new_piece(is_black);
            this->board[x][y] = &new_piece;
            cout << "hello : " << this->board[x][y]->is_black << "\n";
            this->check_board(x, y);
        }

        void display()
        {
            long total_items = this->width * this->height;
            int row = 0;
            for (int i = 0; i < total_items; i++)
            {
                int col = i % width;
                if (this->board[col][row] != nullptr) {
                    cout << "[Item " << col << "-" << row;
                    cout << "hello : " << this->board[2][2]->is_black;
                }
                else 
                {
                    cout << "[Null], ";
                }
                if (col == width - 1)
                {
                    row++;
                    cout << "\n";
                }
            }
            cout << "\n";
        }

    private:
        Piece* board[8][8] = {nullptr};
        int width;
        int height;

        void check_board(int x, int y)
        {
            
        }
};

int main()
{
    Board board(8, 8);
    board.place_piece(0, 0, 0);
    board.place_piece(2, 2, 1);
    board.place_piece(3, 2, 0);
    board.place_piece(4, 2, 1);
    board.display();
    return 0;
}