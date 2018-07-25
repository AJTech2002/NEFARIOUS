using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NNet {

    Matrix inP;

    public Matrix h1Weights;
    Matrix h1;

    public Matrix h2Weights = new Matrix(3, 3, "Hidden -> Hidden");
    Matrix h2;

    public Matrix outPWeights;
    Matrix outP;

    public NNet (Matrix input)
    {
        inP = input;
        inP.Name("Input");
        outP = new Matrix(1, 3, "Output matrix");

        h2 = new Matrix(1, 3, "Hidden Layer 2");
        h1 = new Matrix(1, 3, "Hidden Layer 1");

        outPWeights = new Matrix(3, 3, "Hidden 2 -> Output");
        h2Weights = new Matrix(3, 3, "Hidden -> Hidden");
        h1Weights = new Matrix(inP.yLen, 3, "Input -> Hidden");

        outPWeights.RandomiseValues(-1, 1, false);
        h2Weights.RandomiseValues(-1, 1, false);
        h1Weights.RandomiseValues(-1, 1, false);

        inP.Print();
        h1Weights.Print();
        h1Weights.PrintColumn(1);
        h1.Print();
        h2Weights.Print();
        h2.Print();
        outPWeights.Print();
        outP.Print();


    }

    public Matrix ForwardPropogate(Matrix newInput)
    {

        newInput.SigmoidActivateMatrix();
        h1 = newInput.RetProduct(h1Weights);
        h1.SigmoidActivateMatrix();
        h2 = h1.RetProduct(h2Weights);
        h2.SigmoidActivateMatrix();
        outP = h2.RetProduct(outPWeights);
        outP.SigmoidActivateMatrix();
       // outP = outP.RetSigmoidDerivativeMatrix();

        return outP;
    }

    public void Randomise()
    {
        outPWeights.RandomiseValues(-10, 10, false);
        h2Weights.RandomiseValues(-10, 10, false);
        h1Weights.RandomiseValues(-10, 10, false);
    }

    public void ChangeNetwork (float fitnessDecrease)
    {
        float f = h2.activate(fitnessDecrease);

        for (int i = 0; i < 3; i++)
        {
            Index highestOutputToW2 = outPWeights.HighestInColumn(i);
            Index highestW2ToW1 = h2Weights.HighestInColumn(highestOutputToW2.x);
            Index highestW1ToInput = h1Weights.HighestInColumn(highestW2ToW1.x);

            outPWeights.v[highestOutputToW2.x, highestOutputToW2.y] = Mathf.Clamp(outPWeights.v[highestOutputToW2.x, highestOutputToW2.y]+f,-1f,1f);
            h2Weights.v[highestW2ToW1.x, highestW2ToW1.y] = Mathf.Clamp(h2Weights.v[highestW2ToW1.x, highestW2ToW1.y] + f, -1f, 1f); 
            h1Weights.v[highestW1ToInput.x, highestW1ToInput.y] = Mathf.Clamp(h1Weights.v[highestW1ToInput.x, highestW1ToInput.y] + f, -1f, 1f);
            /*
            Debug.Log("OUTPUT : " + i);
            Debug.Log("______________________________");
            Debug.Log("Highest In Outp -> W2 : " + highestOutputToW2.x + " , " + highestOutputToW2.y + " = " + outPWeights.v[highestOutputToW2.x,highestOutputToW2.y]);
            Debug.Log("Highest In W2 -> W1 : " + highestW2ToW1.x + " , " + highestW2ToW1.y + " = " + h2Weights.v[highestW2ToW1.x, highestW2ToW1.y]);
            Debug.Log("Highest In W1 -> INP : " + highestW1ToInput.x + " , " + highestW1ToInput.y + " = " + h1Weights.v[highestW1ToInput.x, highestW1ToInput.y]);
            */
        }

    }



}
