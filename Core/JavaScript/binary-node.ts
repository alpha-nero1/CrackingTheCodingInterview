class BinaryNode<TData> {
    left?: BinaryNode<TData>;
    right?: BinaryNode<TData>;
    value: TData;
    height: number;

    constructor(value: TData, left?: BinaryNode<TData>, right?: BinaryNode<TData>) {
        this.value = value;
        this.left = left;
        this.right = right;
        this.height = 0;
    }

    setRight(node?: BinaryNode<TData>) {
        this.right = node;
        this.right!.height = this.height + 1;
    }

    setLeft(node?: BinaryNode<TData>) {
        this.left = node;
        this.left!.height = this.height + 1;
    }

    leftValue(): TData | undefined {
        if (!this.left) return;
        return this.left.value;
    }

    rightValue(): TData | undefined {
        if (!this.right) return;
        return this.right?.value;
    }

    toString(): string {
        return `[BinaryNode value:${this.value}, left:${this.leftValue() ?? ''}, right:${this.rightValue() ?? ''}]`;
    }
}