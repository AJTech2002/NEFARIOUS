using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NNet {

    Matrix inP;

    public Matrix h1Weights;
    Matrix h1;

    public Matrix h2Weights;
    Matrix h2;

    public Matrix outPWeights;
    Matrix outP;

    public NNet (Matrix input)
    {
        inP = input;
        inP.Name("Input");
        outP = new Matrix(1, 4, "Output matrix");

        h2 = new Matrix(1, 3, "Hidden Layer 2");
        h1 = new Matrix(1, 3, "Hidden Layer 1");

        outPWeights = new Matrix(3, 4, "Hidden 2 -> Output");
        h2Weights = new Matrix(3, 3, "Hidden -> Hidden");
        h1Weights = new Matrix(inP.yLen, 3, "Input -> Hidden");

        outPWeights.RandomiseValues(-10, 10, false);
        h2Weights.RandomiseValues(-10, 10, false);
        h1Weights.RandomiseValues(-10, 10, false);

        inP.Print();
        h1Weights.Print();
        h1.Print();
        h2Weights.Print();
        h2.Print();
        outPWeights.Print();
        outP.Print();

        Debug.Log("Being Randomised?");
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



}
