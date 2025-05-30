# Sentiment Analysis, Fraud Detection with .NET Core & ML.NET

![image](https://github.com/user-attachments/assets/f23f0ba3-1a56-4225-9a61-e8f4b7e5ef7d)

**OVERVIEW**

This project leverages the power of .NET Core and ML.NET to perform two key tasks:

 - **Sentiment Analysis**: Classify text data to determine the sentiment (positive, negative).

 - **Fraud Detection**: Analyze transactional data to detect potential fraud.

Users upload CSV files containing labeled datasets, which are then used to train machine learning models. Once trained, these models predict sentiment or fraud likelihood on new data.

**FEATURES**

 - Easy CSV Upload: Load your dataset directly via CSV files.

 - Model Training: Automatic training on uploaded data using ML.NET’s powerful algorithms; Stochastic Dual Coordinate Ascent (SDCA) Logistic Regression and Fast Forest algorithm.

 - Scalable & Extensible: Built on .NET Core for cross-platform compatibility and easy integration.

**PREREQUISITES**

- Sentiment Analysis Training Data File should have **_Text, Label_** labels.

- Fraud Detection Training Data File should have **_TransactionId, Amount, HourOfDay, MerchantCategory, Location, TransactionType, HistoricalAvgAmount, NumTransactionsLast24h, IsFraud_** labels.

**TECHNOLOGIES**
 
- .NET Core

- ML.NET

- C#
