class Node {
    constructor(prev, next, value) {
        this.prev = prev;
        this.next = next;
        this.value = value;
    }
}

class CircularArray {
    constructor() {
        this.head = null;
        this.count = 0;
    }

    push(item) {
        if (this.head == null) {
            this.head = new Node(null, null, item);
        } else {
            let newEndNode = this.setNewEnd(item);
            if (newEndNode.prev) {
                
            }
            newEndNode.next = this.head;
        }
        this.count += 1;
    }

    setNewEnd(item) {
        let node = this.head;
        if (!this.head) return;
        while (node != null) {
            if (node.next == null) {
                node.next = new Node(node, null, item);
                return node.next;
            }
            node = node.next;
        }
    }

    pop() {
        let node = this.head;
        if (!this.head) return;
        while (node != null) {
            if (node.next == null) {
                node.prev.next = null;
                this.count -= 1;
                return;
            }
            node = node.next;
        }
    }

    reverse() {
        
    }

    forEach(callback) {
        let node = this.head;
        let i = 0;
        if (!this.head) return;
        while (node != null) {
            callback(node, i);
            node = node.next;
            i++;
        }
    }

    display() {
        process.stdout.write('[CircularArray: ');
        this.forEach((node, i) => {
            const comma = i !== (this.count - 1) ? ', ' : '';
            process.stdout.write(node.value + `${comma}`);
        });
        process.stdout.write(']');
        console.log();
    }
}


const arr = new CircularArray();
arr.push(1);
arr.push(2);
arr.push(4);
arr.push(7);
arr.pop();
arr.display();