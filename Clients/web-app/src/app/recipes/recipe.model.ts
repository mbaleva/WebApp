export interface Recipe{
    id: number;
    name: string;
    instructions: string;
    categoryId: number;
    preparationTime: number;
    cookingTime: number;
    portionsCount: number;
    imageUrl: string;
}