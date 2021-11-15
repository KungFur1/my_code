#pragma once
/*
struct Deque createDeque() - returns newly allocated deque;

All procedures take Deque pointer as their first parameter, for refrence.
Only use pointers to your data!
Use the following methods to Push/Pop elements from Left/Right side of the list:
void pushLeftElement(struct Deque *deque_ptr, void *data_ptr)
void *popLeftElement(struct Deque *deque_ptr)
void pushRightElement(struct Deque *deque_ptr, void *data_ptr)
void *popRightElement(struct Deque *deque_ptr)

Use this procedure to free whole deque:
void freeDeque(struct Deque *deque_ptr, void (*freeElement)(void*)) - function freeElement should free the data type that was used in deque
Exampple: freeElement(void *element) { free(element); }
If there is not enough space for allocation left, the methods print out error and terminate the process.
*/
struct Deque
{
    struct DequeElement *left_element_address;
    struct DequeElement *right_element_address;
};
typedef struct Deque Deque;

struct Deque *createDeque();
void pushLeftElement(struct Deque *deque_ptr, void *data_ptr);
void *popLeftElement(struct Deque *deque_ptr);
void pushRightElement(struct Deque *deque_ptr, void *data_ptr);
void *popRightElement(struct Deque *deque_ptr);
void freeDeque(struct Deque *deque_ptr, void (*freeElement)(void*));
