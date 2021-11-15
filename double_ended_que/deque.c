#pragma once
#include "deque.h"
#include <stdlib.h>
#include <stdio.h>


static struct DequeElement
{
    void *data_ptr;
    struct DequeElement *right_element_address;
    struct DequeElement *left_element_address;
};
static void changeDequeLeftElementAddress(struct Deque *deque_ptr, struct DequeElement *element_ptr);
static void changeDequeRightElementAddress(struct Deque *deque_ptr, struct DequeElement *element_ptr);
static struct DequeElement *createDequeElement();


struct Deque *createDeque()
{
    struct Deque *ret_val = (struct Deque*)malloc(sizeof(struct Deque));
    ret_val->left_element_address = NULL;
    ret_val->right_element_address = NULL;
    return ret_val;
}

void pushLeftElement(struct Deque *deque_ptr, void *data_ptr)
{
    struct DequeElement *deque_element_ptr = createDequeElement();
    if(deque_element_ptr == NULL)
    {
        fprintf(stderr, "\nDeque out of memory!\n");
        return;
    }
    deque_element_ptr->data_ptr = data_ptr;
    if(deque_ptr->left_element_address == NULL)
    {
        deque_ptr->left_element_address = deque_element_ptr;
        deque_ptr->right_element_address = deque_element_ptr;
        deque_element_ptr->right_element_address = NULL;
        deque_element_ptr->left_element_address = NULL;
    }
    else
    {
        deque_ptr->left_element_address->left_element_address = deque_element_ptr;
        deque_element_ptr->right_element_address = deque_ptr->left_element_address;
        deque_ptr->left_element_address = deque_element_ptr;
        deque_element_ptr->left_element_address = NULL;
    }
}

void *popLeftElement(struct Deque *deque_ptr)
{
    struct DequeElement *ret_val_element = deque_ptr->left_element_address;
    void* ret_val = NULL;
    if (ret_val_element != NULL)
    {
        changeDequeLeftElementAddress(deque_ptr, deque_ptr->left_element_address->right_element_address);
        if(deque_ptr->left_element_address != NULL)
        {
            deque_ptr->left_element_address->left_element_address = NULL;
        }
        ret_val = ret_val_element->data_ptr;
    }
    free(ret_val_element);
    return ret_val;
}

void pushRightElement(struct Deque *deque_ptr, void *data_ptr)
{
    struct DequeElement *deque_element_ptr = createDequeElement();
    if(deque_element_ptr == NULL)
    {
        fprintf(stderr, "\nDeque out of memory!\n");
        return;
    }
    deque_element_ptr->data_ptr = data_ptr;
    if(deque_ptr->right_element_address == NULL)
    {
        deque_ptr->left_element_address = deque_element_ptr;
        deque_ptr->right_element_address = deque_element_ptr;
        deque_element_ptr->right_element_address = NULL;
        deque_element_ptr->left_element_address = NULL;
    }
    else
    {
        deque_ptr->right_element_address->right_element_address = deque_element_ptr;
        deque_element_ptr->left_element_address = deque_ptr->right_element_address;
        deque_ptr->right_element_address = deque_element_ptr;
        deque_element_ptr->right_element_address = NULL;
    }
}

void *popRightElement(struct Deque *deque_ptr)
{
    struct DequeElement *ret_val_element = deque_ptr->right_element_address;
    void* ret_val = NULL;
    if (ret_val_element != NULL)
    {
        changeDequeRightElementAddress(deque_ptr, deque_ptr->right_element_address->left_element_address);
        if(deque_ptr->right_element_address != NULL)
        {
            deque_ptr->right_element_address->right_element_address = NULL;
        }
        ret_val = ret_val_element->data_ptr;
    }
    free(ret_val_element);
    return ret_val;
}

void freeDeque(struct Deque *deque_ptr, void (*freeElement)(void*))
{
    // Freeing from left to right
    struct DequeElement *element_ptr, *previous_element_ptr;
    element_ptr = deque_ptr->left_element_address;
    previous_element_ptr = element_ptr;
    while(element_ptr != NULL)
    {
        (*freeElement)(previous_element_ptr->data_ptr);
        free(previous_element_ptr);
        previous_element_ptr = element_ptr;
        element_ptr = element_ptr->right_element_address;
    }
    free(deque_ptr);
}

static void changeDequeLeftElementAddress(Deque *deque_ptr, struct DequeElement *element_ptr)
{
    if(deque_ptr->left_element_address == deque_ptr->right_element_address)
    {
        deque_ptr->right_element_address = element_ptr;
    }
    deque_ptr->left_element_address = element_ptr;
}
static void changeDequeRightElementAddress(struct Deque *deque_ptr, struct DequeElement *element_ptr)
{
    if(deque_ptr->left_element_address == deque_ptr->right_element_address)
    {
        deque_ptr->left_element_address = element_ptr;
    }
    deque_ptr->right_element_address = element_ptr;
}

static struct DequeElement *createDequeElement()
{
    struct DequeElement *ret_val = (struct DequeElement*)malloc(sizeof(struct DequeElement));
    if(ret_val == NULL)
    {
        return NULL;
    }
    ret_val->left_element_address = NULL;
    ret_val->right_element_address = NULL;
    ret_val->data_ptr = NULL;
    return ret_val;
}
